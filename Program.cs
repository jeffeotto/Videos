﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Videos_Exercises
{


    class Program
    {

        public static List<User> Users = new List<User>();

        static void Main(string[] args)
        {

            MainMenu();
            static void MainMenu()
            {
                Console.WriteLine("Hola, para registrarse pulse R , para entrar pulse E");


                var option = Console.ReadLine().ToUpper();


                while (true)
                {

                    if (String.IsNullOrEmpty(option))
                    {
                        Console.WriteLine("Campo vacío, por favor elije una las opciones arriba.");
                        option = Console.ReadLine();
                    }

                    if (option == "R")
                    {
                        Console.Clear();
                        RegisterMenu();

                    }

                    else if (option == "E")
                    {
                        Console.Clear();
                        UploadVideos();
                    }


                }
            }

            static void RegisterMenu()
            {

                Console.WriteLine("Register");

                Console.WriteLine("Opción: s - para salir");
                Console.WriteLine("Opción: a - para registrarse");

                while (true)
                {
                    var option = Console.ReadLine();

                    if (option == "s")
                    {
                        break;
                    }

                    else if (option == "a")
                    {
                        Console.WriteLine("Para salir - s.");
                        Console.WriteLine("Escriba el nombre:");


                        var name = Console.ReadLine();

                        if (name == "s")
                            break;

                        while (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Campo vacío, por favor elije una las opciones arriba.");
                            name = Console.ReadLine();
                        }


                        Console.WriteLine("Introduce Apellidos, para salir - s");
                        var secName = Console.ReadLine();

                        if (secName == "s")
                            break;

                        while (String.IsNullOrEmpty(secName))
                        {
                            Console.WriteLine("Campo vacío, por favor elije una las opciones arriba.");
                            secName = Console.ReadLine();
                        }

                        Console.WriteLine("Introduce password - 4 números");
                        var pass = Console.ReadLine();
                        int passValue;

                        var success = Int32.TryParse(pass, out passValue);

                        while (success == false || passValue.ToString().Length < 4)
                        {
                            Console.WriteLine("Sólo números, 4 dígitos por favor");
                            pass = Console.ReadLine();
                            success = Int32.TryParse(pass, out passValue);

                        }


                        var user = new User
                        {
                            Name = name,
                            GivenName = secName,
                            Pass = passValue,


                        };

                        Users.Add(user);

                        foreach (var u in Users)
                        {
                            Console.WriteLine($"{u.Name} {u.GivenName} {u.Pass} {u.date}");

                        }

                        break;

                    }
                }

                Console.WriteLine();
                MainMenu();
            }

            static void UploadVideos()
            {

                Console.WriteLine("User Menu - Por favor Introduce tu Password de 4 dígitos, para salir - s");
                var option = Console.ReadLine();

                if (option == "s")
                {
                    MainMenu();
                }

                while (String.IsNullOrEmpty(option))
                {
                    Console.WriteLine("Campo vacío, por favor elije una las opciones arriba.");
                    option = Console.ReadLine();
                }
                int value;
                var pass = Int32.TryParse(option, out value);

                if (option == "s")
                {
                    MainMenu();
                }

                foreach (var user in Users)
                {
                    if (user.Pass == value)
                    {
                        Console.WriteLine($"Hola {user.Name}");

                        Console.WriteLine("Opción: s - para salir");
                        Console.WriteLine("Opción: a - adicionar videos ");
                        Console.WriteLine("Opción: v - ver lista");
                        Console.WriteLine("Opción: t - Tag your videos");
                        Console.WriteLine("Opción: r - Reproducción");

                        while (true)
                        {
                            var handleAction = Console.ReadLine();
                            if (handleAction == "s")
                            {
                                break;
                            }



                            else if (handleAction == "a")
                            {
                                Console.WriteLine("Para salir - s.");
                                Console.WriteLine("Escribe el título del vídeo:");


                                var title = Console.ReadLine();

                                if (title == "s")
                                    break;

                                while (String.IsNullOrEmpty(title))
                                {
                                    Console.WriteLine("Campo vacío, por favor elije una las opciones arriba.");
                                    title = Console.ReadLine();
                                }

                                var myVideo = new Video
                                {
                                    Title = title
                                };

                                user.AddVideos(myVideo);
                                Console.WriteLine("Tag your video. Para salir - s ");

                                var i = 0;
                                while (true)
                                {
                                    var tagVideo = Console.ReadLine();
                                    if (tagVideo == "s")
                                    {

                                        break;
                                    }
                                    else
                                    {
                                        myVideo.AddTags(tagVideo);

                                    }

                                    i++;
                                }
                               

                                foreach (var tag in myVideo.Tags)
                                {
                                    Console.WriteLine($"Tags: \n {tag}");
                                }

                                Console.WriteLine("Opción: s - Para salir");
                                Console.WriteLine("Opción: a - Adicionar videos ");
                                Console.WriteLine("Opción: v - Ver lista");
                                Console.WriteLine("Opción: t - Tag your videos");
                                Console.WriteLine("Opción: r - Reproducción");

                            }

                            else if (handleAction == "v")
                            {
                                foreach (var v in user.MyVideos)
                                {
                                    Console.WriteLine($"Video Title: {v.Title} \n Video Url: {v.Url}");
                                }
                            }


                            else if (handleAction == "r")
                            {

                                foreach (var p in user.MyVideos)
                                {
                                    Console.WriteLine($"Video Title: {p.Title}");

                                }

                                Console.WriteLine("Elije video para reproducir escribiendo el título.");

                                var videoToPlay = Console.ReadLine();

                                user.MyVideos.Select(videoToPlay => videoToPlay.Title);
                                Console.WriteLine(videoToPlay);



                                Console.WriteLine("Opción: r - Reproducir video");
                                Console.WriteLine("Opción: p - Pausar videos ");
                                Console.WriteLine("Opción: s - Parar video");
                                var statusVideo = Console.ReadLine();

                                while (true)
                                {


                                    if (statusVideo == "r")
                                    {
                                        VideoStatus play = VideoStatus.Playing;
                                        Console.WriteLine($"{videoToPlay} is {play}");
                                        Console.WriteLine("Opción: p - Pausar videos ");
                                        Console.WriteLine("Opción: s - Parar video");
                                        statusVideo = Console.ReadLine();
                                    }
                                    else if (statusVideo == "p")
                                    {
                                        VideoStatus pause = VideoStatus.Paused;
                                        Console.WriteLine($"{videoToPlay} is {pause}");
                                        Console.WriteLine("Opción: r - Reproducir video");
                                        Console.WriteLine("Opción: s - Parar video");
                                        Console.WriteLine("Opción: e - Parar salir");
                                        statusVideo = Console.ReadLine();
                                    }
                                    else if (statusVideo == "s")
                                    {
                                        VideoStatus stop = VideoStatus.Stopped;
                                        Console.WriteLine($"{videoToPlay} is {stop}");
                                        Console.WriteLine("Opción: r - Reproducir video");
                                        Console.WriteLine("Opción: e - Parar salir");
                                        statusVideo = Console.ReadLine();

                                    }
                                    else
                                    {
                                        break;
                                    }

                                    Console.WriteLine("Opción: s - Para salir");
                                    Console.WriteLine("Opcion: a - Adicionar videos ");
                                    Console.WriteLine("Opción: v - Ver lista");
                                    Console.WriteLine("Opción: t - Tag your videos");
                                    Console.WriteLine("Opción: r - Leproducción");
                                }

                            }


                        }

                       
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado");
                        MainMenu();
                    }
                }


            }

        }
    }

    public enum VideoStatus
    {
        Playing,
        Paused,
        Stopped
    }

    public class Video
    {
        private string title;
        private string url;
        private User user;
        public List<string> Tags = new List<string>();


        public User User
        {
            get { return this.user; }
            set { user = User; }
        }


        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Url
        {
            get { return this.url = $"yourvideo{title}.com"; }
            set { this.url = $"yourvideo{title}.com"; }
        }

        public void AddTags(string tag)
        {

            Tags.Add(tag);

        }



    }

    public class User
    {

        private string name;
        private string givenname;
        private int password;
        public DateTime date { get; set; }
        public List<Video> MyVideos { get; set; }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string GivenName
        {
            get { return givenname; }
            set { givenname = value; }
        }

        public int Pass
        {
            get { return password; }
            set { password = value; }
        }


        public User()
        {
            MyVideos = new List<Video>();

        }


        public bool AddVideos(Video video)
        {
            video.User = this;
            MyVideos.Add(video);

            return true;
        }

    }

}
