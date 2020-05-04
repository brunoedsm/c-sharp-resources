/*
    Scenario to use singleton:
    A chord creator
    For better reference, please visit https://www.dofactory.com/net/design-patterns
*/

using System;
using System.Collections.Generic;

namespace brunoedsm.creational.console
{

    public static class SingletonPlayer
    {
        public static void PlayExample()
        {
            ServerLoadBalancer b1 = ServerLoadBalancer.GetLoadBalancer();
            ServerLoadBalancer b2 = ServerLoadBalancer.GetLoadBalancer();
            ServerLoadBalancer b3 = ServerLoadBalancer.GetLoadBalancer();
            ServerLoadBalancer b4 = ServerLoadBalancer.GetLoadBalancer();

            // Same instance?

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests

            ServerLoadBalancer balancer = ServerLoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }
    }

    // abstracts

    // concretes
    class ServerLoadBalancer
    {
        private static ServerLoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();
        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor (protected)
        protected ServerLoadBalancer()
        {
            // List of available servers

            _servers.Add("AWS EC2 Server");
            _servers.Add("Azure Virtual Server");
            _servers.Add("OpenShift Server");
            _servers.Add("Heroku Dyno");
            _servers.Add("Google GCP Server");
        }

        public static ServerLoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ServerLoadBalancer();
                    }
                }
            }

            return _instance;
        }
        public string Server
        {
            get

            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }

}