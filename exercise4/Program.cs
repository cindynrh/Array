using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseAlgo4
{
    class Node
    {
        public int NomorSiswa;
        public string Name;
        public Node Next;
    }
    class CircularList

    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public void AddNode()
        {
            int StudentNo;
            string Nama;
            Console.Write("\nMasukkan Nomor Siswa: ");
            StudentNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nomor Siswa: ");
            Nama = Console.ReadLine();
            Node newNode = new Node();
            newNode.NomorSiswa = StudentNo;
            newNode.Name = Nama;

            if (LAST == null || StudentNo <= LAST.NomorSiswa)
            {
                if ((LAST != null) && (StudentNo == LAST.NomorSiswa))
                {
                    Console.WriteLine("\nNomor Siswa Ganda tidak diperbolehkan\n");
                    return;
                }
                newNode.Next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (StudentNo >= current.NomorSiswa))
            {
                if (StudentNo == current.NomorSiswa)
                {
                    Console.WriteLine("\nNomor Siswa Ganda tidak diperbolehkan\n");
                    return;
                }
                previous = current;
                current = current.Next;
            }
            newNode.Next = current;
            previous.Next = newNode;
        }
        public bool Delete(int StudentNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(StudentNo, ref previous, ref current) == false)
                return false;
            previous.Next = current.Next;
            if (current == LAST)
                LAST = LAST.Next;
            return true;
        }
        public bool Search(int StudentNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.Next; current != LAST; previous = current, current = current.Next)
            {
                if (StudentNo == current.NomorSiswa)
                    return (true);
            }
            if (StudentNo == LAST.NomorSiswa)
                return true;
            else
                return (false);
        }
        public bool ListEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void Traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nDaftar kosong");
            else
            {
                Console.WriteLine("\nRecord in the list are: \n");
                Node currentNode;
                currentNode = LAST.Next;
                for (currentNode = LAST; currentNode != null; currentNode = currentNode.Next)
                    Console.Write(currentNode.NomorSiswa + " " + currentNode.Name + "\n");
                Console.WriteLine();
            }
        }
        public void firstNode()
        {
            if (ListEmpty())
                Console.WriteLine("\nDaftar kosong");
            else
                Console.WriteLine("\nRekor pertama dalam daftar adalah: \n\n" + LAST.Next.NomorSiswa + " " + LAST.Next.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();

            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice(1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.AddNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of" + "the student whose record is to be deleted: ");
                                int StudentNo = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();
                                if (obj.Delete(StudentNo) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                    Console.WriteLine("Record with roll number " + StudentNo + " deleted ");

                            }
                            break;
                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not Found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nStudent Number: " + curr.NomorSiswa);
                                    Console.WriteLine("\nName: " + curr.Name);
                                }
                            }
                            break;
                        case '5':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

//Essay
/*1.Explain the difference between using a linked list data structure and using an
array!
2.Explain the difference between a single linked list, a double linked list, and a
circular linked list!
3. Mention an example application that implements a single linked list, double and
circular linked list linked list.
4. Describe the advantages of using dynamic data structures ?
5.Describe the process of adding data for the single linked list, double linked list
and circular linked list algorithms!
6. Describe the process of data deletion algorithm for single linked list, double and
circular linked list linked list!
7. Describe the process of data search algorithm for single linked list, double and
circular linked list linked list!
8. Describe the process for displaying the data for a single algorithm linked list,
double and circular linked list linked list!

//Answer
1. Array adalah struktur data berbasis indeks di mana setiap elemen terkait dengan indeks. 
Lalu, Linked list bergantung pada referensi di mana setiap node terdiri dari data dan referensi
ke elemen sebelumnya dan berikutnya jadi Perbedaan utama antara Array dan daftar Linked berkaitan 
dengan struktur mereka.

2. - Single linked list : hanya memiliki 1 variabel pointer saja sehingga menghabiskan lebih sedikit memori. 
Pointer juga menunjuk ke node selanjutnya dan biasanya field pada tail menunjuk ke NULL 
- Double linked list: memiliki 2 variabel pointer sehingga lebih banyak memori per node(2 Node). 
Pointer juga menunjuk ke node selanjutnya dan pointer yang menunjuk ke node sebelumnya. 
Setiap head dan tailnya juga menunjuk ke NULL
- Circular linked list : suatu link list dimana tail atau node terakhir menunjuk ke head atau node pertama. 
Jadi tidak ada pointer yang menunjuk NULL.

3. - Aplikasi Single Linked List  digunakan untuk Pembuatan aplikasi DNA, pemetaan DNA manusia.
- Double linked list ini contohnya untuk bekerja dengan data.Pada Navigasi data depan dan belakang sangat 
digunakan, membangun cache yang paling baru digunakan dan selain itu digunakan untuk membangun struktur data yang berbeda 
- Circular linked list digunakan untuk implementasi struktur data tingkat lanjut seperti Fibonacci Heap.
Contoh ada beberapa aplikasi berjalan di PC, lalu sistem operasi akan menempatkan aplikasi yang sedang berjalan pada daftar 
lalu kemudian menggilirnya, setelah itu memberi masing-masing potongan waktu untuk dieksekusi, dan Lebih mudah 
bagi sistem operasi untuk menggunakan Circular linked list sehingga ketika akhir daftar, dapat berputar ke bagian depan daftar.

4. Membuat penggunaan memori secara efisien. Penyimpanan tidak lagi membutuhkan dapat dikembalikan untuk sistem untuk penggunaan lain.

5. single link list  =
• Alokasikan memori untuk node baru.
• Tetapkan nilai ke bidang data node baru.
• Jika START adalah NULL, maka:
• Buat titik MULAI ke simpul baru.
• Pergi ke langkah 6.
• Cari node terakhir dalam daftar, dan tandai sebagai currentNode. Untuk menemukan node terakhir dalam daftar, jalankan langkah-langkah berikut:
• Tandai node pertama sebagai currentNode.
• Ulangi langkah c sampai penerus currentNode menjadi NULL.
• Buat titik Node saat ini ke node berikutnya secara berurutan.
• Buat field selanjutnya dari currentNode menunjuk ke node baru.
• Buat bidang berikutnya dari titik simpul baru ke NULL.
double link list = 
- Memasukkan Node di Awal Daftar (Lanjutan)
• Alokasikan memori untuk node baru.
• Tetapkan nilai ke bidang data node baru.
• Buat bidang berikutnya dari simpul baru menunjuk ke simpul pertama dalam daftar.
• Buat bidang sebelumnya dari START menunjuk ke simpul baru.
• Buat bidang sebelumnya dari titik simpul baru ke NULL.
• Buat MULAI, arahkan ke simpul baru.
- Menyisipkan Node Antara Dua Node dalam Daftar (Lanjutan)
• Identifikasi node di antara node baru yang akan disisipkan. Tandai masing-masing sebagai sebelumnya dan saat ini. Untuk menemukan sebelumnya dan saat ini, jalankan langkah-langkah berikut:
Buat titik saat ini ke simpul pertama.
Buat poin sebelumnya ke NULL.
Ulangi langkah d dan e hingga current.info > newnode.info atau current = NULL.
Buat poin sebelumnya menjadi saat ini.
Buat titik saat ini ke node berikutnya secara berurutan.
• Alokasikan memori untuk node baru.
• Tetapkan nilai ke bidang data node baru.
• Buat bidang berikutnya dari titik simpul baru menjadi saat ini.
• Buat bidang sebelumnya dari titik simpul baru ke sebelumnya.
• Buat bidang sebelumnya dari titik saat ini ke simpul baru.
• Buat bidang berikutnya dari titik sebelumnya ke simpul baru.
circular linked list = 
-Memasukkan Di Awal daftar
•	Buat Node baru dengan nilai yang diberikan.
•	Periksa apakah daftar Kosong (head == NULL)
•	Jika Kosong, atur head = newNode dan newNode→next = head .
•	Jika Tidak Kosong, tentukan 'temp' penunjuk Node dan inisialisasi dengan 'kepala'.
•	Terus pindahkan 'temp' ke node berikutnya hingga mencapai node terakhir (sampai 'temp → next == head').
•	Atur 'newNode → next =head', 'head = newNode' dan 'temp → next = head'.
-Memasukkan Di Akhir daftar
•	Buat Node baru dengan nilai yang diberikan.
•	Periksa apakah daftar Kosong (head == NULL).
•	Jika Kosong, atur head = newNode dan newNode → next = head.
•	Jika Tidak Kosong, tentukan suhu penunjuk simpul dan inisialisasi dengan kepala.
•	Terus pindahkan temp ke node berikutnya hingga mencapai node terakhir dalam daftar (sampai temp → next == head).
•	Atur temp → next = newNode dan newNode → next = head.
-Memasukkan Di lokasi tertentu dalam daftar (Setelah Node)
•	Buat Node baru dengan nilai yang diberikan.
•	Periksa apakah daftar Kosong (head == NULL)
•	Jika Kosong, atur head = newNode dan newNode → next = head.
•	Jika Tidak Kosong, tentukan suhu penunjuk simpul dan inisialisasi dengan kepala.
•	Terus pindahkan temp ke node berikutnya hingga mencapai node setelah itu kita ingin memasukkan newNode (sampai temp1 → data sama dengan lokasi, di sini lokasi adalah nilai node setelah itu kita ingin memasukkan newNode) .
•	Setiap kali periksa apakah temp tercapai ke node terakhir atau tidak. Jika sudah mencapai simpul terakhir maka tampilkan 'Node yang diberikan tidak ditemukan dalam daftar!!! Penyisipan tidak mungkin!!!' dan mengakhiri fungsi. Jika tidak, pindahkan suhu ke simpul berikutnya.
•	Jika temp tercapai ke node yang tepat setelah itu kita ingin memasukkan newNode kemudian periksa apakah itu node terakhir (temp → next == head).
•	Jika temp adalah node terakhir maka atur temp → next = newNode dan newNode → next = head.
•	Jika temp bukan simpul terakhir maka setel newNode → next = temp → next dan temp → next = newNode.

6. - single linked list 
• Menghapus Node Dari Awal Daftar (Lanjutan)
• Tandai node pertama dalam daftar sebagai saat ini.
• Buat titik MULAI ke simpul berikutnya dalam urutannya.
• Lepaskan memori untuk node yang ditandai sebagai saat ini.
- double linked list
--Menghapus Node Dari Awal Daftar (Lanjutan)
• Tandai node pertama dalam daftar sebagai saat ini.
• Buat titik MULAI ke simpul berikutnya secara berurutan.
• Jika START bukan NULL: // Jika node yang akan dihapus bukan satu-satunya node dalam daftar //
Tetapkan NULL ke bidang sebelumnya dari simpul yang ditandai sebagai MULAI.
• Lepaskan memori node yang ditandai sebagai saat ini.
-- Menghapus Node Antara Dua Node dalam Daftar (Lanjutan)
• Tandai node yang akan dihapus sebagai saat ini dan pendahulunya seperti sebelumnya. Untuk menemukan sebelumnya dan saat ini, jalankan langkah-langkah berikut:
Buat poin sebelumnya ke NULL. // Setel sebelumnya = NULL
Buat titik saat ini ke simpul pertama dalam daftar tertaut. // Setel arus = MULAI
Ulangi langkah d dan e sampai node ditemukan atau arus menjadi NULL.
Buat poin sebelumnya menjadi saat ini.
Buat titik saat ini ke node berikutnya secara berurutan.
• Buat bidang berikutnya dari titik sebelumnya ke penerus saat ini.
• Membuat bidang prev penerus titik saat ini ke sebelumnya.
• Lepaskan memori node yang ditandai sebagai saat ini.
-Circular linked list
-- Menghapus Node Dari Awal Daftar (Lanjutan)
• Jika node yang akan dihapus adalah satu-satunya node dalam daftar: // Jika LAST menunjuk ke dirinya sendiri
Tandai TERAKHIR sebagai NULL
keluar
• Buat poin saat ini ke penerus LAST
• Jadikan bidang terakhir dari titik TERAKHIR ke penerus arus
• Lepaskan memori untuk simpul yang ditandai sebagai saat ini
-	Menghapus Node Antara Dua Node dalam Daftar
• Buat poin sebelumnya ke penerus LAST
• Buat poin saat ini ke penerus LAST
• Ulangi langkah 4 dan 5 sampai salah satu simpul ditemukan, atau sebelumnya = TERAKHIR
• Buat poin sebelumnya menjadi saat ini
• Buat titik saat ini ke node berikutnya secara berurutan
-- Menghapus Node Dari Akhir Daftar (Lanjutan)
• Buat titik saat ini ke TERAKHIR.
• Tandai pendahulu LAST sebagai sebelumnya. Untuk menemukan pendahulu LAST, 
jalankan langkah-langkah berikut:
Buat poin sebelumnya ke penerus LAST.
Ulangi langkah c sampai penerus sebelumnya menjadi TERAKHIR.
Buat titik sebelumnya ke node berikutnya secara berurutan.
• Buat field berikutnya dari titik sebelumnya menjadi penerus LAST.
• Tandai sebelumnya sebagai TERAKHIR.
• Lepaskan memori untuk node yang ditandai sebagai saat ini.

7. - single linked list
• Dimulai dari node (set ke Head of list), dan node terakhir (setel ke NULL awalnya) diberikan.
• Tengah dihitung menggunakan pendekatan dua petunjuk.
• Jika data tengah cocok dengan nilai pencarian yang diperlukan, kembalikan.
• Else if jika data tengah <nilai, pindah ke upper half(pengaturan mulai ke tengah berikutnya).
• Else pergi ke bagian bawah (pengaturan terakhir ke tengah).
- double linked list
• perlu menelusuri daftar untuk mencari elemen tertentu dalam daftar. Lakukan operasi berikut untuk mencari operasi tertentu.
• Salin penunjuk kepala ke variabel penunjuk sementara ptr.
• mendeklarasikan variabel lokal I dan menetapkannya ke 0.
• Lintasi daftar hingga penunjuk ptr menjadi nol. Terus geser penunjuk ke berikutnya dan tingkatkan i sebesar +1.
• Bandingkan setiap elemen daftar dengan item yang akan dicari.
• Jika item cocok dengan nilai simpul apa pun maka lokasi nilai itu saya akan dikembalikan dari fungsi yang lain NULL dikembalikan.
- circular linked list
• Node pertama adala Head untuk setiap Linked list
• Ketika sebuah linked list baru dibuat ia hanya memiliki head yaitu NULL
• Else head memegang penunjuk ke node pertama dari daftar
• Saat ingin menambahkan node apapun didepan, kita harus mengarah head nya kesana
• Dan penunjuk berikutnya dari node yang baru ditambahkan, harus menunjuk ke head sebelumnya, 
apakah itu NULL atau penunjuk node pertama dari list
• Head node sebelumnya sekarang menjadi node kedua dari linked list, karena node baru ditambahkan didepan

8.- Single Linked List
• Periksa apakah daftar Kosong (head == NULL)
• Jika Kosong maka, tampilkan 'Daftar Kosong!!!' dan mengakhiri fungsi.
• Jika Tidak Kosong, tentukan 'temp' penunjuk Node dan inisialisasi dengan kepala.
• Tetap tampilkan temp → data dengan tanda panah (--->) hingga temp mencapai node terakhir
• Terakhir tampilkan temp → data dengan panah menunjuk ke NULL (temp → data ---> NULL).
- Double linked list
• Periksa apakah daftar Kosong (head == NULL).
• Jika Kosong, maka tampilkan 'List is Empty' dan hentikan fungsinya.
• Jika Tidak Kosong, tentukan penunjuk Node 'temp' dan inisialisasi dengan head.
• Tetap tampilkan temp -> data dengan panah (--->) sampai temp mencapai node terakhir.
• Akhirnya menampilkan temp -> data dengan panah menunjuk ke head → data.
-Circular Linked list
• Periksa apakah daftar Kosong (head == NULL)
• Jika Kosong, maka tampilkan 'Daftar Kosong!!!' dan mengakhiri fungsi.
• Jika Tidak Kosong, tentukan 'temp' penunjuk Node dan inisialisasi dengan kepala.
• Tetap tampilkan temp → data dengan tanda panah (--->) hingga temp mencapai node terakhir
• Akhirnya menampilkan temp → data dengan panah menunjuk ke kepala → data.
*/
