using System;
using System.Collections.Generic;
using System.Text;

namespace Dekret_CSharpLab1.Model
{
    class User
    {
        private int _age;
        private DateTime _birthDate;
        private string _userSunZodiac;
        private string _userChineseZodiac;

        private string[] SunZodiac = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };
        private string[] ChineseZodiac = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };


        public User()
        {
            _birthDate = System.DateTime.UtcNow;
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
        }

        public string UserSunZodiac
        {
            get
            {
                return _userSunZodiac;
            }
        }

        public string UserChineseZodiac
        {
            get
            {
                return _userChineseZodiac;
            }
        }


        public bool processData()
        {
            _age = System.DateTime.UtcNow.Year - _birthDate.Year;
            if (System.DateTime.UtcNow < _birthDate || Age > 135)
            {
                return false;
            }

            #region SuunZodiac
            uint shzodiac = (uint)((_birthDate.Year - 1900) % 12);
            _userSunZodiac = SunZodiac[shzodiac];
            #endregion

            #region ChineseZodiac
            uint chzodiac = (uint)((_birthDate.Year-1900) % 12);
            _userChineseZodiac = ChineseZodiac[chzodiac];
            #endregion

            return true;
        }

        public bool todayBirthday()
        {
            return System.DateTime.UtcNow.Date == _birthDate.Date;
        }
    }
}
