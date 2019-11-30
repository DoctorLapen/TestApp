using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
//Класс который эмулирует работу Web-сервера
namespace Assets.Scripts
{
    public static class WebServerEmulator
    {
        private static string[] jsonArr= new string [3];

        static WebServerEmulator()
        {
            InitJsonArr();
        }
        /*
         * Метод который инициализирует jsonArr
         * Данными из json-файлов в папке JsonFolder
        */
        private static void InitJsonArr()
        {
            string path;
            string data;
            for (int i = 0; i < 3; i++) {
                path = Path.Combine(Application.dataPath, $"JsonFolder/Test{i+1}.json");
                data = File.ReadAllText(path);
                jsonArr[i] = data;
            }
        }
        //метод которыий возвращает случайную json-строку из jsonArr
        public static string GetJsonData()
        {
            int randomInt = UnityEngine.Random.Range(0,3);
            return jsonArr[randomInt];
        }
    }
}