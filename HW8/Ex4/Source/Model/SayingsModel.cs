using System;
using System.Collections.Generic;

namespace Ex4.Model
{
    [Serializable]
    public class SayingsModel
    {
        private Random _rnd;
        
        private List<string> _firstParts;
        private List<string> _lastParts;

        public SayingsModel()
        {
            _firstParts = new List<string>();
            _lastParts = new List<string>();
            _rnd = new Random();
        }

        public List<string> FirstParts
        {
            get => _firstParts;
            set => _firstParts = value;
        }

        public List<string> LastParts
        {
            get => _lastParts;
            set => _lastParts = value;
        }

        public string GetFirstPart(int index)
        {
            return GetPart(_firstParts, index);

        }

        public string GetLastPart(int index)
        {
            return GetPart(_lastParts, index);
        }

        private string GetPart(List<string> partList, int index)
        {
            if (partList == null || index < 0 || index >= partList.Count)
            {
                return null;
            }

            return partList[index];
        }

        public void AddItem(string firstPart, string lastPart)
        {
            if (_firstParts == null || _lastParts == null)
            {
                return;
            }
            
            _firstParts.Add(firstPart);
            _lastParts.Add(lastPart);
        }

        public string GetSaying()
        {
            string firstPart = _firstParts[_rnd.Next(0, _firstParts.Count)];
            string lastPart = _lastParts[_rnd.Next(0, _lastParts.Count)];
            return $"{firstPart} - {lastPart}";
        }
    }
}