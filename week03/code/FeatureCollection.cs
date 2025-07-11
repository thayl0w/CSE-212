public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public string Place { get; set; }
    public double Mag { get; set; }
}