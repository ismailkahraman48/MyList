using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sehirler = new List<string>();
            sehirler.Add("İstanbul");
            Console.WriteLine(sehirler.Count);  //bana liste içindekilerin sayısını verir Count=Property

            Mylist<string> sehirler2 = new Mylist<string>();    // ben burda listemi int yada string tanımladım string de tanımlayabilirdim ne istersem tanımlarım 
                // class içindeki T bunu sağlar.
            sehirler2.Add("Fethiye");
            Console.WriteLine(sehirler2.Count);
        }
    }
    class Mylist<T>         // type anlamına gelen T kullanırız istediğimizi kullanabiliriz. arka planda listeler, array ile çalışır.
                            // clasın çalışma tipini gösterir hangi tiple çalışacağını ayarlamak için tanımlarız
    
    
    {
        T[] _array;         //T tipinde bir array tanımlıyorum
        T[] _temparray;
        public Mylist()
        {
            _array = new T[0];      // array newlendiğinde eleman sayısı 0 olduğu için 0 elemanlı array den başlıyorum.
        }

        public void Add(T item)        // T türünde bir item parametre olarak isteyecek yani ben ne tür bir tip tanımlarsam listem o tipi tanıyacak.
        {
            _temparray = _array;                // temparray burda array in referasını tutar veri kaybını engeller.
            _array = new T[_array.Length + 1];  // eleman sayısını artırmak için newlemem gerekiyor , eleman sayısını 1 arttırdım.
                                                //eleman sayısı artırdığımda geride kalan veriler silindiği için önceden verilerin yedeğini almam gerekir.
            for (int i = 0; i < _temparray.Length; i++) // for tab x2
            { // 0 dan başlar temparray uzunluğundan küçük olana kadar çalışır
                _array[i] = _temparray[i];  // burda newlediğim için kaybettiğim arrayi referans temparray den tekrar alıyorum.
            }

            _array[_array.Length - 1] = item; //son elemanada benim gönderdiğim değeri alıp listeye ekleceyek.

        }

         //propful tab x2

        public int Count        // my listin countunu çağırdığımda arrayin uzunluğunu bana döndürecek
        {
            get { return _array.Length; }
            
        }


    }
}
