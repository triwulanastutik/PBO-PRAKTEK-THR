using System;

class Karyawan
{
    // Atribut
    private string nama;
    private string id;
    private double gaji;

    // Property untuk mengakses nama
    public string Nama
    {
        get { return this.nama; }
        set { this.nama = value; }
    }

    // Property untuk mengakses ID
    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    // Property untuk mengakses Gaji
    public double Gaji
    {
        get { return this.gaji; }
        set { this.gaji = value; }
    }

    // Method virtual untuk menghitung gaji
    public virtual double HitungGaji()
    {
        return this.gaji;
    }
}

// Class turunan untuk karyawan tetap
class KaryawanTetap : Karyawan
{
    public override double HitungGaji()
    {
        return this.Gaji + 500000; // Bonus tetap
    }
}

// Class turunan untuk karyawan kontrak
class KaryawanKontrak : Karyawan
{
    public override double HitungGaji()
    {
        return this.Gaji - 200000; // Potongan kontrak
    }
}

// Class turunan untuk karyawan magang
class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return this.Gaji; // Gaji tetap
    }
}

class Data
{
    static void Main(string[] args)
    {
        // Input data karyawan
        Console.WriteLine("Masukkan kedudukan Karyawan (tetap/kontrak/magang): ");
        string kedudukan = Console.ReadLine();
        if (string.IsNullOrEmpty(kedudukan))
        {
            Console.WriteLine("Kedudukan tidak boleh kosong.");
            return;
        }

        Console.Write("Masukkan Nama Karyawan : ");
        string nama = Console.ReadLine();
        if (string.IsNullOrEmpty(nama))
        {
            Console.WriteLine("Nama tidak boleh kosong.");
            return;
        }

        Console.Write("Masukkan ID Karyawan : ");
        string id = Console.ReadLine();
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("ID tidak boleh kosong.");
            return;
        }

        Console.Write("Masukkan Gaji : ");
        double gaji;
        if (!double.TryParse(Console.ReadLine(), out gaji))
        {
            Console.WriteLine("Gaji harus berupa angka.");
            return;
        }

        // Deklarasi objek karyawan sesuai kedudukan
        Karyawan karyawan = null;

        if (kedudukan.ToLower() == "tetap")
        {
            karyawan = new KaryawanTetap();
        }
        else if (kedudukan.ToLower() == "kontrak")
        {
            karyawan = new KaryawanKontrak();
        }
        else if (kedudukan.ToLower() == "magang")
        {
            karyawan = new KaryawanMagang();
        }
        else
        {
            Console.WriteLine("Kedudukan tidak dikenali.");
            return;
        }

        // Set data ke objek
        karyawan.Nama = nama;
        karyawan.Id = id;
        karyawan.Gaji = gaji;

        // Hitung dan tampilkan hasil
        double gajiAkhir = karyawan.HitungGaji();

        Console.WriteLine("\n=== Data Karyawan ===");
        Console.WriteLine("Nama Karyawan : " + karyawan.Nama);
        Console.WriteLine("ID Karyawan   : " + karyawan.Id);
        Console.WriteLine("Jabatan       : " + kedudukan);
        Console.WriteLine("Gaji Akhir    : Rp" + gajiAkhir);
    }
}
