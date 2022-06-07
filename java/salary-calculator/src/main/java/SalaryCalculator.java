public class SalaryCalculator {
    public double multiplierPerDaysSkipped(int daysSkipped) {
        return daysSkipped < 5 ? 1 : .85;
    }

    public int multiplierPerProductsSold(int productsSold) {
        return productsSold < 20 ? 10 : 13;
    }

    public double bonusForProductSold(int productsSold) {
        return multiplierPerProductsSold(productsSold) * productsSold;
    }

    public double finalSalary(int daysSkipped, int productsSold) {
        return Math.min(1000.0 * multiplierPerDaysSkipped(daysSkipped) + bonusForProductSold(productsSold),2000.0);
    } 
}
