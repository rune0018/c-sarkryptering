// See https://aka.ms/new-console-template for more information
using cæsarkryptering;

//string alltext = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
//Console.WriteLine("whatwould you like to encrypt");
//Console.WriteLine(encrypt.krypt("hej"));
//Console.WriteLine(encrypt.krypt("JGL",-2));
//Console.WriteLine(encrypt.krypt("FDS", 20));
//Console.WriteLine(encrypt.krypt(encrypt.krypt("FDS", 20), -20));
//Console.WriteLine(encrypt.krypt("HEJSA", -36));
//for(int i = 0;i<26;i++)
//{
//    Console.Write(encrypt.freq_norm[i].ToString()+ " ");
//}
//Console.WriteLine();
//Console.WriteLine();
//string input = @"LQNGPG LQNGPG LQNGPG LQNGPG
//QJ K'O DGIIKPI QH AQW RNGCUG FQP'V VCMG OA OCP
//LQNGPG LQNGPG LQNGPG LQNGPG
//RNGCUG FQP'V VCMG JKO GXGP VJQWIJ AQW ECP
 
//AQWT DGCWVA KU DGAQPF EQORCTG
//YKVJ HNCOKPI NQEMU QH CWDWTP JCKT
//YKVJ KXQTA UMKP CPF GAGU QH GOGTCNF ITGGP
 
//AQWT UOKNG KU NKMG C DTGCVJ QH URTKPI
//AQWT UMKP KU UQHV NKMG UWOOGT TCKP
//CPF K ECP PQV EQORGVG YKVJ AQW LQNGPG
 
//CPF K ECP GCUKNA WPFGTUVCPF
//JQY AQW EQWNF GCUKNA VCMG OA OCP
//DWV AQW FQP'V MPQY YJCV JG OGCPU VQ OG LQNGPG
 
//JG VCNMU CDQWV AQW KP JKU UNGGR
//VJGTG'U PQVJKPI K ECP FQ VQ MGGR
//HTQO ETAKPI YJGP JG ECNNU AQWT PCOG LQNGPG LQNGPG";
//foreach (double a in encrypt.frequency(input))
//{
//    Console.Write(a.ToString() + " ");
//}
//Console.Clear();
//for (int i = 0; i < 26; i++)
//{
//    Console.Write(encrypt.freq_norm[i].ToString() + " ");
//}
//Console.WriteLine();
//Console.WriteLine();

//Console.WriteLine( encrypt.autodecrypt(input));
//Console.ReadKey();
//Console.Clear();
//Console.WriteLine(encrypt.advancedencrypt("", ""));
string test = encrypt.advancedencrypt("hejasdadas", "POP");
Console.WriteLine("hejasdadas".ToUpper() == encrypt.advanceddecrypt(test, "POP"));