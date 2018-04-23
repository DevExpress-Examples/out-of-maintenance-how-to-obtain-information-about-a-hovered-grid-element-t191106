using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dxSample {
    public class Person {
        public Person() {
            
        }
        // Fields...
        private DateTime _Birthdate;
        private string _Name;
        private int _ID;

        public int ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }


        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        public DateTime Birthday {
            get {
                return _Birthdate;
            }
            set {
                _Birthdate = value;
            }
        }
    }
}
