public class Lasagna {

    public int expectedMinutesInOven(){
        return 40;
    }

  public int remainingMinutesInOven(int elapsed){
      return expectedMinutesInOven()- elapsed;
  }

    public int preparationTimeInMinutes(int layers){
        return layers * 2;
    }

    public int totalTimeInMinutes(int layers, int elapsed){
return preparationTimeInMinutes(layers) + elapsed;
    }
}
