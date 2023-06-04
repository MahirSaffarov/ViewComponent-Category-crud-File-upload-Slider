using System;
using Fiorello.Models;

namespace Fiorello.ViewModels
{
	public class HomeVM
	{
        public List<Blog> blogs { get; set; }
        public List<Experts> experts { get; set; }
        public Valentine valentine { get; set; }
        public List<About> abouts { get; set; }
        public List<Instagram> instagrams { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Image> images { get; set; }
    }
}

