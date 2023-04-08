// See https://aka.ms/new-console-template for more information
using tpmodul8_1302213012;

CovidConfig covConfig = new CovidConfig();
covConfig.UbahSatuan();

Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + covConfig.config.satuan_suhu);
string temperatureTubuh = Console.ReadLine();
int temperature = (int)Convert.ToInt32(temperatureTubuh);

Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
string dayIn = Console.ReadLine();
int day = (int)Convert.ToInt32(dayIn);

if (covConfig.config.satuan_suhu == "celcius")
{
    if (temperature > 37.5)
    {
        if (day > covConfig.config.batas_hari_demam)
        {
            Console.WriteLine(covConfig.config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(covConfig.config.pesan_diterima);
        }
    }
    else
    {
        Console.WriteLine(covConfig.config.pesan_diterima);
    }
}
else if (covConfig.config.satuan_suhu == "fahrenheit")
{
    if (temperature > 99.5)
    {
        if (day > covConfig.config.batas_hari_demam)
        {
            Console.WriteLine(covConfig.config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(covConfig.config.pesan_diterima);
        }
    }
    else
    {
        Console.WriteLine(covConfig.config.pesan_diterima);
    }
}
