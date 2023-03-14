using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace AprendendoFiles2
{
    class Program
    {
        [System.Serializable] // serialização: Converter qualquer tipo em um conjunto de bytes, para que possa salvar variaveis daquele tipo em um arquivo binario
        struct Produto
        {
            public string nome;
            public float preco;
        }
        static void Main(string[] args)
        {
            int a = 120;
            string nome = "Daniela Marques";
            float b = 12.2f;
            //FileStream serve tanto para leitura quanto para escrita
            //filemode = de que modo você quer trabalhar com essa string
            //Open or Create = Abrir e criar
            //Append= caso queira adicionar novas informações no arquivo
          
            List<string> langs = new List<string>();
            langs.Add("C#");
            langs.Add("JavaScript");
            langs.Add("PHP");

            Produto banana = new Produto();
            banana.nome  = "Banana";
            banana.preco = 1F;


            FileStream stream = new FileStream("meuarquivo.daniela", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            /*encoder.Serialize(stream, langs); //Serialização é o processo de salvamento em um arquivo binario
            encoder.Serialize(stream, banana);
            encoder.Serialize(stream, nome);
            encoder.Serialize(stream, a);
            encoder.Serialize(stream, b);*/

            List<string> listaDoArquivo = (List<string>)encoder.Deserialize(stream); //Deserialização é o processo de leitura
            Produto prod = (Produto)encoder.Deserialize(stream);

            Console.WriteLine(listaDoArquivo[0]);
            Console.WriteLine(prod.nome) ;
            stream.Close();

        }
    }
}
