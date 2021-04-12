namespace store_front_server.Models
{
  public class Listing
  {
    //NOTE might have to change the public options and the set get on price
    public string name { set; get; }
    public string description { set; get; }
    public int price { set; get; }
    //want to create a way to upload images instead.. possibly
    public string img { set; get; }
  }
}