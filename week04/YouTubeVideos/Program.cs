using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        // Create some videos
        Video video1 = new Video("C# Abstract classes and methods in 8 minutes", "tutorialsEU", 500);
        Video video2 = new Video("C# Abstract classes", "Bro Code", 156);
        Video video3 = new Video("Abstract Class vs Interface (Real Application USe)", "Interview Happy", 378);

        // Add comments to video1
        video1.AddComment(new Comment("@dennisdevink5667", "Clear and fast! Thanks"));
        video1.AddComment(new Comment("@Drougar108", "Thank you i had 4 hours of sleep and i needed to get some more abstact and interface info into my brain, and as it is this weeks class subject and im trying to cram it in there."));
        video1.AddComment(new Comment("@sanjaytharan622", "This one is a saver!!! Thanks alot"));

        // Add comments to video2
        video2.AddComment(new Comment("@Fraps224", "your explanations are awesome"));
        video2.AddComment(new Comment("@faycaled3058", "After 2 years of coding I've finally understand what is the purpose of this abstract thanks to you !"));

        // Add comments to video3
        video3.AddComment(new Comment("@marquismccan4068", "This is the one abstract class video that actually makes sense to me thank you"));
        video3.AddComment(new Comment("@zeenatfirdoshquadri1699", "months of confusion minutes of solution... thanku its very lucid"));
        video3.AddComment(new Comment("@naveenbaghel5327", "I have no word for your knowledge, awesome happy rawat ji"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display the details of each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}