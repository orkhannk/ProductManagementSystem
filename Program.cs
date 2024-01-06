
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "Iphone", "Slmsung", "Nokia", "Xiaomi", "Huawei" };
            string opt;
            do
            {



                Console.WriteLine("\n ========== Menu ==========");
                Console.WriteLine("1.Butun mehsullara bax ");
                Console.WriteLine("2.Secilmis mehsula bax");
                Console.WriteLine("3.Yeni mehsul elave et");
                Console.WriteLine("4.Mehsul adini deyis");
                Console.WriteLine("5.Secilmis mehsulu sil ");
                Console.WriteLine("0.Cix");
                Console.WriteLine("Emeliyyati secin :");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.WriteLine("\n ========== Mehsullar ==========");
                        ShowAllProducts(products);
                        break;
                    case "2":
                        Console.WriteLine("\n indexi daxil edin :");
                        string indexStr = Console.ReadLine();
                        try
                        {
                            int index = Convert.ToInt32(indexStr);
                            Console.WriteLine($"mehsul :{products[index]}");

                        }
                        catch
                        {
                            Console.WriteLine("Xeta bas verdi !");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\n ========== Yeni Mehsul ========== ");
                        string mehsul;
                       
                        do
                        {
                            Console.WriteLine("Yeni elave olunacaq mehsulun adinin uzunluqu 2 ile 20 arasinda deyismelidir!!! :");
                            mehsul = Console.ReadLine();
                        }
                        while (mehsul.Length < 2 || mehsul.Length > 20);
                        
                        AddNewProduct(ref products, mehsul);
                        

                            break;

                    case "4":
                        bool hasproblem;
                        Console.WriteLine("\n ========== Mehsullar ==========");
                        ShowAllProducts(products);
                        do
                        {
                            hasproblem = false;
                            try
                            {
                                EditProduct(products);

                            }
                            catch
                            {
                                Console.WriteLine("Xeta bas verdi !");
                                hasproblem = true;

                            }

                        }
                        while (hasproblem);
                        break;

                    case "5":
                        RemoveProduct(products);
                        break;
                        

                        

                }
            }
            while (opt != "0");




            static void ShowAllProducts(string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"{i}.{arr[i]}");
                }
            }


            static void AddNewProduct(ref string[] array ,string element)
            {
                
                string[] newArray = new string[array.Length + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                newArray[newArray.Length - 1] = element;
                array = newArray;
                bool hasproblems = false;
                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] == element)
                    {
                        hasproblems = true;
                        break;
                    }
                }
                if (hasproblems)
                {
                    Console.WriteLine("bu adli mehsul elave ede bilmezsiz cunki artiq movcuddur!");
                }
                

            }




            static string RemoveStartAndEndSpaces(string str)
            {
                string newStr = "";
                int startIndex = FindFirstNonSpaceIndex(str);
                int endIndex = FindLastNonSpaceIndex(str);

                if (startIndex == -1) return newStr;

                for (int i = startIndex; i <= endIndex; i++)
                {
                    newStr += str[i];
                }

                return newStr;


            }

            static int FindFirstNonSpaceIndex(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ' ') return i;
                }
                return -1;
            }

            static int FindLastNonSpaceIndex(string str)
            {
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (str[i] != ' ') return i;
                }

                return -1;
            }


            static void EditProduct(string[] products)
            {
                Console.WriteLine("mehsulu secin :");
                string indexStr = Console.ReadLine();
                int index = Convert.ToInt32(indexStr);
                Console.WriteLine("yeni ad daxil edin :");
                products[index] = Console.ReadLine();

            }

            static void RemoveProduct(string[] products)
            {
                Console.WriteLine("secilmis mehsulunun indeksini daxil edin :");
                string indexStr = Console.ReadLine();
                int index = Convert.ToInt32(indexStr);
                string[] newArr = new string[products.Length - 1];
                int index1 = 0;
                for(int i = 0; i < products.Length; i++)
                {
                    if (i != index)
                    {
                        newArr[index1] = products[i];
                        index1++;
                    }
                }
                for(int i = 0; i < newArr.Length; i++)
                {
                    Console.WriteLine(newArr[i]);
                }
            }
           
            
        }
    }
}
