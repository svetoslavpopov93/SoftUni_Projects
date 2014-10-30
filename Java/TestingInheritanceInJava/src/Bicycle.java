
public class Bicycle implements IBicycleRide {
	int gear;
    int speed;
    int cadance;
    
    public Bicycle(int gear, int speed, int cadance) {
		super();
		this.gear = gear;
		this.speed = speed;
		this.cadance = cadance;
	}

	@Override
	public void changeGear(int gearValue) {
		gear = gearValue;
	}

	@Override
	public void changeSpeed(int speedValue) {
		speed = speedValue;
	}

	@Override
	public void changeCadance(int cadanceValue) {
		cadance = cadanceValue;
	}

	@Override
	public void rideBicycle() {
		System.out.println("Yeah, im riding my bike on " + gear + " gear with " + speed + "km speed!");
	}

	@Override
	public String toString() {
		return "Bicycle [gear=" + gear + ", speed=" + speed + ", cadance="
				+ cadance + "]";
	}
    
}
