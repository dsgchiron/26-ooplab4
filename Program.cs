using System;

namespace Lab4_5
{
    class Program
    {
        // Сортування вибором
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        // Бінарний пошук з підрахунком кількості входжень
        static int BinarySearchCount(int[] arr, int key)
        {
            int left = 0;
            int right = arr.Length - 1;
            int foundIndex = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == key)
                {
                    foundIndex = mid;
                    break;
                }
                else if (arr[mid] < key)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (foundIndex == -1) return 0;

            int count = 1;
            int i = foundIndex - 1;
            while (i >= 0 && arr[i] == key)
            {
                count++;
                i--;
            }

            int j = foundIndex + 1;
            while (j < arr.Length && arr[j] == key)
            {
                count++;
                j++;
            }

            return count;
        }

        // Послідовний (лінійний) пошук
        static int LinearSearchCount(int[] arr, int key)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key) count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int K = 26;
            int N = (int)(20 + 0.6 * K); // N = 35
            int[] array = new int[N];
            Random rnd = new Random();

            Console.WriteLine($"Розмір масиву N = {N}");
            Console.WriteLine("Вихідний масив:");
            for (int i = 0; i < N; i++)
            {
                array[i] = rnd.Next(10, 101);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n");

            SelectionSort(array);

            Console.WriteLine("Відсортований масив (Сортування вибором):");
            for (int i = 0; i < N; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n");

            Console.Write("Введіть ключове значення для пошуку: ");
            int key = int.Parse(Console.ReadLine());

            int countBinary = BinarySearchCount(array, key);
            int countLinear = LinearSearchCount(array, key);

            Console.WriteLine($"Результат бінарного пошуку: елемент {key} зустрічається {countBinary} раз(ів).");
            Console.WriteLine($"Результат послідовного пошуку: елемент {key} зустрічається {countLinear} раз(ів).");

            Console.ReadLine();
        }
    }
}