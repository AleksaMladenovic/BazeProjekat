using DatabaseAccess.DTOs;
using MuzickaSkolaLibrary;

public class NastavnikView
{
    public OsobaView OsnovniPodaci { get; set; }
    public DateTime? DatumZaposlenja { get; set; }
    public string StrucnaSprema { get; set; }
    public string? MentorPunoIme { get; set; }

    public int BrojCasovaKojeDrzi { get; set; }
    public int BrojKursevaKojeVodi { get; set; }

    public NastavnikView() { }

    internal NastavnikView(Nastavnik? n)
    {
        if (n != null)
        {
            this.OsnovniPodaci = new OsobaView(n.OsnovniPodaci);

            this.DatumZaposlenja = n.OsnovniPodaci.DatumZaposlenja;
            this.StrucnaSprema = n.OsnovniPodaci.StrucnaSprema;
            this.MentorPunoIme = n.OsnovniPodaci.Mentor != null ? $"{n.OsnovniPodaci.Mentor.OsnovniPodaci.Ime} {n.OsnovniPodaci.Prezime}" : "Nema mentora";

            this.BrojCasovaKojeDrzi = n.DrziCasove?.Count ?? 0;
            this.BrojKursevaKojeVodi = n.VodiKurseve?.Count ?? 0;
        }
    }

    public static NastavnikView KreirajNastavnikView(Nastavnik? nastavnikEntitet)
    {
        if (nastavnikEntitet == null)
        {
            return null;
        }
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();
            StalnoZaposlen sz = s.Get<StalnoZaposlen>(nastavnikEntitet.Id);
            if (sz != null)
            {
                return new StalnoZaposlenView(sz);
            }
            Honorarac h = s.Get<Honorarac>(nastavnikEntitet.Id);
            if (h != null)
            {
                return new HonoraracView(h);
            }
            else
            {
                throw new ArgumentException("Nepoznat tip nastavnika.", nameof(nastavnikEntitet));
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            s.Close();
        }
    }


    public static NastavnikView VratiNastavnika(int nastavnikId)
    {
        NastavnikView nastavnikView = null;
        ISession s = null;
        try
        {
            s = DataLayer.GetSession();
            StalnoZaposlen sz = s.Get<StalnoZaposlen>(nastavnikId);
            if (sz != null)
            {
                return new StalnoZaposlenView(sz);
            }
            Honorarac h = s.Get<Honorarac>(nastavnikId);
            if (h != null)
            {
                return new HonoraracView(h);
            }
            else
            {
                throw new ArgumentException("Nepoznat tip nastavnika.", nameof(nastavnikId));
            }
        }
        catch (Exception ex) { throw; }
        finally { s?.Close(); }

    }
}

public class NastavnikCreateView
{
    public string Jmbg { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string? Adresa { get; set; }
    public string? Telefon { get; set; }
    public string? Email { get; set; }
    public DateTime? DatumZaposlenja { get; set; }
    public string? StrucnaSprema { get; set; }
    public int? IdMentora { get; set; }

    public string TipZaposlenja { get; set; } // Očekivane vrednosti: "Honorarac" ili "StalnoZaposlen"

    public string? BrojUgovora { get; set; }
    public string? TrajanjeUgovora { get; set; }
    public int? BrojCasova { get; set; }

    public string? RadnoVreme { get; set; }
}
public class NastavnikBasicView
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }

    public NastavnikBasicView() { }

    internal NastavnikBasicView(Nastavnik n)
    {
        if (n != null)
        {
            Id = n.Id;
            if (n.OsnovniPodaci != null)
            {
                Ime = n.OsnovniPodaci.Ime;
                Prezime = n.OsnovniPodaci.Prezime;
            }
        }
    }
}

