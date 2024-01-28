namespace _Scripts.Services.RandomService
{
    public interface IRandomService
    {
        int Next(int minValue, int maxValue);

        float Next(float minValue, float maxValue);
    }
}