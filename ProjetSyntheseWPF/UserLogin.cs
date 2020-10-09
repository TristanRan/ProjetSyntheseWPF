using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSyntheseWPF
{
    public class UserLogin
    {

        string _id, _mdp, _nom, _role;
        

        public string Id { get => _id; set => _id = value; }
        public string Mdp { get => _mdp; set => _mdp = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Role { get => _role; set => _role = value; }
        

        public UserLogin() { }
        public UserLogin(string pId, string pMdp)
        {
            _id = pId;
            _mdp = pMdp;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nMdp: {Mdp}";
        }

    }
}
