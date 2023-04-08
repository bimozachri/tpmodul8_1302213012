using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302213012
{
    internal class CovidConfig
    {
        public Config config;

        private const string filepath = @"covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            string baca = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<Config>(baca);
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string write = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, write);
        }

        public void SetDefault()
        {
            config = new Config();

            config.satuan_suhu = "celcius";
            config.batas_hari_demam = 14;
            config.pesan_ditolak = "anda tidak diperbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void UbahSatuan()
        {
            string baca = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<Config>(baca);

            if (config.satuan_suhu.Contains("celcius"))
            {
                config.satuan_suhu = "fahrenheit";
            }
            else if (config.satuan_suhu.Contains("fahrenheit"))
            {
                config.satuan_suhu = "celcius";
            }

            string newJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filepath, newJson);
        }
    }

    public class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public Config() { }

        public Config(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }
}
