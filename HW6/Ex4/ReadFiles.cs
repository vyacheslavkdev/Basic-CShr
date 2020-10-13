/*
 * Вячеслав Индорил
 * Задача 4
    **Считайте файл различными способами. Смотрите “Пример записи файла различными способами”.
    Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader 
    и массив int для BinaryReader.
 */

using System;
using System.IO;

namespace Ex4
{
    class ReadFiles
    {
        private static string text =
            "**Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. " +
            "Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader " +
            "и массив int для BinaryReader.";

        static void Main(string[] args)
        {
            ReadForFileStreamSample("../../bigdata0.bin", 10);
            ReadFromBinaryStreamSample("../../textData.bin", text);
            ReadFromStreamReaderSample("../../textData1.bin", text);
            ReadFromBufferedStreamSample("../../buffData.bin", 100);
        }

        static byte[] ReadForFileStreamSample(string filename, long size)
        {
            try
            {
                Random rnd = new Random();
                FileStream fileStream = new FileStream(filename, FileMode.Create);
                for (int i = 0; i < size; i++)
                {
                    fileStream.WriteByte((byte) rnd.Next(0, 128));
                }

                fileStream.Close();

                fileStream = new FileStream(filename, FileMode.Open);
                byte[] res = new byte[size];
                fileStream.Read(res);
                fileStream.Close();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static int[] ReadFromBinaryStreamSample(string filename, string text)
        {
            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.Create);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);

                for (int i = 0; i < text.Length; i++)
                {
                    binaryWriter.Write(text[i]);
                }

                binaryWriter.Close();
                fileStream.Close();

                fileStream = new FileStream(filename, FileMode.Open);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                int[] res = new int[text.Length];
                string textRes = "";

                for (int i = 0; i < text.Length; i++)
                {
                    char readChar = binaryReader.ReadChar();
                    res[i] = readChar;
                    textRes += readChar;
                }

                binaryReader.Close();
                fileStream.Close();

                Console.WriteLine($"Текст совпадает: {textRes.Equals(text)}");

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static string ReadFromStreamReaderSample(string fileName, string text)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(text);
                streamWriter.Close();
                fileStream.Close();

                fileStream = new FileStream(fileName, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);

                string res = "";
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    res += line;
                }

                Console.WriteLine($"Текст совпадает: {res.Equals(text)}");

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static byte[] ReadFromBufferedStreamSample(string filename, int size)
        {
            try
            {
                Random rnd = new Random();
                byte[] gen = new byte[size];
                byte[] res = new byte[size];
                FileStream fileStream = new FileStream(filename, FileMode.Create);
                int partCount = 4;
                int buffSize = (int) size / partCount;
                byte[] buffer = new byte[buffSize];
                BufferedStream bufferedStream = new BufferedStream(fileStream, buffSize);
                for (int i = 0; i < partCount; i++)
                {
                    rnd.NextBytes(buffer);
                    buffer.CopyTo(gen, buffSize * i);
                    bufferedStream.Write(buffer, 0, partCount);
                }

                bufferedStream.Close();
                fileStream.Close();

                fileStream = new FileStream(filename, FileMode.Open);
                bufferedStream = new BufferedStream(fileStream);

                for (int i = 0; i < partCount; i++)
                {
                    bufferedStream.Read(buffer, 0, partCount);
                    buffer.CopyTo(res, buffSize * i);
                }

                bufferedStream.Close();
                fileStream.Close();

                bool equalse = true;
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] != gen[i])
                    {
                        equalse = false;
                    }
                }

                Console.WriteLine($"Массивы равны: {equalse}");

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}