using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Drawing;

namespace ClientMarch
{
   public class connect
    {
        private string ip = "127.0.0.1";
        private int port = 8080;
        private Socket socket;
        byte[] buffer;
        byte[] receive = new byte[2048];
        public user LogIn(string login, string password)
        {
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            user us = new user();

            socket.Send(Encoding.UTF8.GetBytes("user/IN/"+login+"/"+ password));
            int lenght= socket.Receive(receive);
            string answer = Encoding.UTF8.GetString(receive, 0, lenght);
            if(answer.Split('$')[0]=="Error404")
            {
                us.error(answer.Split('$')[0]);
                return us;
            }
            us.post__user((answer.Split('$')[0]),( answer.Split('$')[5] ),( answer.Split('$')[2]+" "+ answer.Split('$')[3]+" "+ answer.Split('$')[4] ), answer.Split('$')[1],answer.Split('$')[6]);
            return us;
        }
        public user connecting()
        {
            user us = new user();
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ip, port);
                socket.Close();
            }
            catch(Exception ex)
            {
                us.error("Error500");
            }
            return us;
        }
        public string add__user(string login, string password, string email,string name, string type)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            user us = new user();

            socket.Send(Encoding.UTF8.GetBytes("user/Add/" + login + "/" + password+"/"+email+"/"+name+"/"+type));
            int lenght = socket.Receive(receive);
            string answer = Encoding.UTF8.GetString(receive, 0, lenght);

            return answer;
        }
        
        public string news ()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            user us = new user();

            socket.Send(Encoding.UTF8.GetBytes("News/get"));
            int lenght = socket.Receive(receive);
            string answer = Encoding.UTF8.GetString(receive, 0, lenght);


            return answer;
        }
        public string get__car(string token)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            user us = new user();

            socket.Send(Encoding.UTF8.GetBytes("Cars/Info/"+token));
            int lenght = socket.Receive(receive);
            string answer = Encoding.UTF8.GetString(receive, 0, lenght);
            return answer;
        }
        public string add_image__user(string token,string Path)
        {
           
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            user us = new user();

            socket.Send(Encoding.UTF8.GetBytes("Cars/Info/" + token));

            socket.SendFile(Path);

            int lenght = socket.Receive(receive);
            string answer = Encoding.UTF8.GetString(receive, 0, lenght);
            return answer;
        }

        public string Connect__Service(string token)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);

            socket.Send(Encoding.UTF8.GetBytes("Service/IN/" + token));

            int lenght = socket.Receive(receive);
            string answer = Encoding.UTF8.GetString(receive, 0, lenght);

            return answer;

        }
    }
}
