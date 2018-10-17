namespace PatHost
{
    public interface IPatAppBuilder
    {
        IPipeline MessagePipeline { get; set; }
        IPipeline BatchPipeline { get; set; }
    }

    public interface IPipeline
    {
        IPipeline UseMiddleware<T>();
    }
}