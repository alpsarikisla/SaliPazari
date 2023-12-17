using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con;SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Giriş

        public Yonetici YoneticiGiris(string kullaniciAdi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.Yetki_ID, YO.Isim, Y.Isim,Y.Soyisim,Y.KullaniciAdi,Y.Sifre,Y.IsDeleted,Y.IsActive FROM Yoneticiler AS Y JOIN YoneticiYetkiler AS YO ON Y.Yetki_ID = YO.ID WHERE Y.KullaniciAdi = @ka AND Y.Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                Yonetici y = null;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    y = new Yonetici();
                    y.ID = reader.GetInt32(0);
                    y.Yetki_ID = reader.GetInt32(1);
                    y.YetkiIsim = reader.GetString(2);
                    y.Isim = reader.GetString(3);
                    y.Soyisim = reader.GetString(4);
                    y.KullaniciAdi = reader.GetString(5);
                    y.Sifre = reader.GetString(6);
                    y.IsDeleted = reader.GetBoolean(7);
                    y.IsActive = reader.GetBoolean(8);
                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori İşlemleri

        public int KategoriEkle(Kategori model)
        {
            int eklenenID = -1;
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim, Aciklama, IsDeleted,IsActive) VALUES(@isim, @aciklama, @isDeleted,@isActive) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", model.Isim);
                cmd.Parameters.AddWithValue("@aciklama", model.Aciklama);
                cmd.Parameters.AddWithValue("@isDeleted", model.IsDeleted);
                cmd.Parameters.AddWithValue("@isActive", model.IsActive);
                con.Open();
                eklenenID = Convert.ToInt32(cmd.ExecuteScalar());
                return eklenenID;
            }
            catch
            {
                return eklenenID;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT * FROM Kategoriler WHERE IsDeleted = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori(okuyucu.GetInt32(0), okuyucu.GetString(1), okuyucu.GetString(2), okuyucu.GetBoolean(3), okuyucu.GetBoolean(4));
                    kat.IsActiveStr = kat.IsActive ? "Aktif" : "Pasif";
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Kategori kat = new Kategori();
                while (okuyucu.Read())
                {
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.IsActive = okuyucu.GetBoolean(3);
                    kat.IsDeleted = okuyucu.GetBoolean(4);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler Set Isim=@isim, Aciklama=@aciklama, IsActive=@isActive WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                cmd.Parameters.AddWithValue("@isActive", kat.IsActive);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Marka İşlemleri

        public int MarkaEkle(Marka model)
        {
            int eklenenID = -1;
            try
            {
                cmd.CommandText = "INSERT INTO Markalar(Isim, IsDeleted,IsActive) VALUES(@isim, @isDeleted,@isActive) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", model.Isim);
                cmd.Parameters.AddWithValue("@isDeleted", model.IsDeleted);
                cmd.Parameters.AddWithValue("@isActive", model.IsActive);
                con.Open();
                eklenenID = Convert.ToInt32(cmd.ExecuteScalar());
                return eklenenID;
            }
            catch
            {
                return eklenenID;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Marka> MarkaListele()
        {
            try
            {
                List<Marka> Markalar = new List<Marka>();
                cmd.CommandText = "SELECT * FROM Markalar WHERE IsDeleted = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    Marka m = new Marka();
                    m.ID = okuyucu.GetInt32(0);
                    m.Isim = okuyucu.GetString(1);
                    m.IsActive = okuyucu.GetBoolean(2);
                    m.IsDeleted = okuyucu.GetBoolean(3);
                    m.IsActiveStr = m.IsActive ? "Aktif" : "Pasif";
                }
                return Markalar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Genel Metotlar

        public bool Sil(string tabloadi, int id)
        {
            try
            {
                cmd.CommandText = "UPDATE " + tabloadi + " SET IsDeleted=1 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
