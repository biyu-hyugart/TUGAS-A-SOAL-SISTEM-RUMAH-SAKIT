using System;
using System.Collections.Generic;

class Orang
{
    private string nama;
    private int umur;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public int Umur
    {
        get { return umur; }
        set { umur = value; }
    }

    public virtual void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang melakukan aktivitas.");
    }

    public void InfoOrang()
    {
        Console.WriteLine("Nama : " + Nama);
        Console.WriteLine("Umur : " + Umur);
    }
}


class Pasien : Orang
{
    private string keluhan;

    public string Keluhan
    {
        get { return keluhan; }
        set { keluhan = value; }
    }

    public void CekKeluhan()
    {
        Console.WriteLine("Keluhan pasien : " + Keluhan);
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang menjalani pemeriksaan.");
    }
}


class TenagaMedis : Orang
{
    private string spesialisasi;

    public string Spesialisasi
    {
        get { return spesialisasi; }
        set { spesialisasi = value; }
    }

    public void CekSpesialis()
    {
        Console.WriteLine("Spesialisasi : " + Spesialisasi);
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang bekerja sebagai tenaga medis.");
    }
}


class Dokter : TenagaMedis
{
    public void Diagnosa()
    {
        Console.WriteLine(Nama + " sedang melakukan diagnosa pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang memeriksa pasien.");
    }
}


class Perawat : TenagaMedis
{
    public void CekPasien()
    {
        Console.WriteLine(Nama + " sedang mengecek kondisi pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang merawat pasien.");
    }
}


class PasienAnak : Pasien
{
    public void Menangis()
    {
        Console.WriteLine(Nama + " sedang menangis.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang diperiksa oleh dokter.");
    }
}


class PasienDewasa : Pasien
{
    public void Konsultasi()
    {
        Console.WriteLine(Nama + " sedang melakukan konsultasi.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang menunggu pemeriksaan.");
    }
}


class RumahSakit
{
    private List<Orang> daftarOrang = new List<Orang>();

    public void TambahOrang(Orang orang)
    {
        daftarOrang.Add(orang);
    }

    public void DaftarOrang()
    {
        Console.WriteLine("=== DAFTAR ORANG DI RUMAH SAKIT ===");

        foreach (Orang orang in daftarOrang)
        {
            orang.InfoOrang();
            Console.WriteLine();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Membuat objek RumahSakit
        RumahSakit rumahSakit = new RumahSakit();

        // Membuat objek Dokter
        Dokter dokter = new Dokter();
        dokter.Nama = "Dr. Andi";
        dokter.Umur = 35;
        dokter.Spesialisasi = "Penyakit Dalam";

        // Membuat objek Perawat
        Perawat perawat = new Perawat();
        perawat.Nama = "Siti";
        perawat.Umur = 28;
        perawat.Spesialisasi = "Perawat Umum";

        // Membuat objek Pasien Anak
        PasienAnak pasienAnak = new PasienAnak();
        pasienAnak.Nama = "Budi";
        pasienAnak.Umur = 8;
        pasienAnak.Keluhan = "Demam";

        // Membuat objek Pasien Dewasa
        PasienDewasa pasienDewasa = new PasienDewasa();
        pasienDewasa.Nama = "Andi";
        pasienDewasa.Umur = 25;
        pasienDewasa.Keluhan = "Sakit kepala";

        // Menambahkan orang ke Rumah Sakit
        rumahSakit.TambahOrang(dokter);
        rumahSakit.TambahOrang(perawat);
        rumahSakit.TambahOrang(pasienAnak);
        rumahSakit.TambahOrang(pasienDewasa);

        // Menampilkan semua data
        rumahSakit.DaftarOrang();

        Console.WriteLine("=== POLYMORPHISM ===");

        Orang orang1 = dokter;
        Orang orang2 = pasienAnak;

        orang1.Aktivitas();
        orang2.Aktivitas();

        Console.WriteLine();

        // Memanggil method khusus
        Console.WriteLine("=== METHOD KHUSUS ===");

        dokter.Diagnosa();
        dokter.CekSpesialis();

        perawat.CekPasien();

        pasienAnak.CekKeluhan();
        pasienAnak.Menangis();

        pasienDewasa.CekKeluhan();
        pasienDewasa.Konsultasi();

        Console.WriteLine();

        // Jawaban soal nomor 5
        Console.WriteLine("=== POLYMORPHISM PERAWAT ===");

        Orang orang3 = perawat;
        orang3.Aktivitas();
    }
}

