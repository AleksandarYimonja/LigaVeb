using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Liga
{
    public class LigaKl
    {
        SqlConnection veza;
        SqlCommand komanda = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public int Unos_Kluba(string naziv)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Dodaj_Klub";

            komanda.Parameters.Add(new SqlParameter("@Naziv", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Izmena_Kluba(int id, string naziv)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Izmeni_Klub";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@Naziv", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Brisanje_Kluba(int id)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Obrisi_Klub";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Unos_Sezone(string naziv)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Dodaj_Sezona";

            komanda.Parameters.Add(new SqlParameter("@Naziv", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Izmena_Sezone(int id, string naziv)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Izmeni_Sezona";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@Naziv", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Brisanje_Sezone(int id)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Obrisi_Sezona";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Unos_Igraca(string ime, string prezime, int klubID)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Dodaj_Igrac";

            komanda.Parameters.Add(new SqlParameter("@Ime", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            komanda.Parameters.Add(new SqlParameter("@Prezime", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            komanda.Parameters.Add(new SqlParameter("@KlubID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, klubID));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Izmena_Igraca(int id, string ime, string prezime, int klubID)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Izmeni_Igrac";

            komanda.Parameters.Add(new SqlParameter("@KlubID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@Ime", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            komanda.Parameters.Add(new SqlParameter("@Prezime", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            komanda.Parameters.Add(new SqlParameter("@KlubID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, klubID));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Obrisi_Igraca(int id)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Obrisi_Igrac";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Unos_Meca(int klub1ID, int klub2ID, string datum, int sezonaID)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Dodaj_Mec";

            komanda.Parameters.Add(new SqlParameter("@Klub1ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, klub1ID));
            komanda.Parameters.Add(new SqlParameter("@Klub2ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, klub2ID));
            komanda.Parameters.Add(new SqlParameter("@Datum", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum));
            komanda.Parameters.Add(new SqlParameter("@SezonaID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sezonaID));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Izmena_Meca(int id, int klub1ID, int klub2ID, string datum, int sezonaID)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Izmeni_Mec";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@Klub1ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, klub1ID));
            komanda.Parameters.Add(new SqlParameter("@Klub2ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, klub2ID));
            komanda.Parameters.Add(new SqlParameter("@Datum", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum));
            komanda.Parameters.Add(new SqlParameter("@SezonaID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sezonaID));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Obrisi_Mec(int id)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Obrisi_Mec";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Unos_Gola(int strelacID, int asistiraoID, int mecID)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Dodaj_Gol";

            komanda.Parameters.Add(new SqlParameter("@StrelacID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strelacID));
            komanda.Parameters.Add(new SqlParameter("@AsistiraoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, asistiraoID));
            komanda.Parameters.Add(new SqlParameter("@MecID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, mecID));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Izmeni_Gol(int id, int strelacID, int asistiraoID, int mecID)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Izmeni_Gol";

            komanda.Parameters.Add(new SqlParameter("@StrelacID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@StrelacID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strelacID));
            komanda.Parameters.Add(new SqlParameter("@AsistiraoID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, asistiraoID));
            komanda.Parameters.Add(new SqlParameter("@MecID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, mecID));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int Obrisi_Gol(int id)
        {
            veza = Konekcija.Connect();
            int rezultat;

            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "dbo.Obrisi_Gol";

            komanda.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            komanda.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();

            int ret;
            ret = (int)komanda.Parameters["@RETURN_VALUE"].Value;
            if (ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }
    }
}