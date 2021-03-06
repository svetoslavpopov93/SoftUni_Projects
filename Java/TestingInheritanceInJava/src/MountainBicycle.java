
public class MountainBicycle extends Bicycle{
	int altitude;
	
	public MountainBicycle(int gear, int speed, int cadance, int altitude) {
		super(gear, speed, cadance);
		this.altitude = altitude;
	}
	
	@Override
	public void changeGear(int gearValue) {
		super.changeGear(gearValue);
	}

	@Override
	public void changeSpeed(int speedValue) {
		super.changeSpeed(speedValue);
	}

	@Override
	public void changeCadance(int cadanceValue) {
		super.changeCadance(cadanceValue);
	}
	
	public void changeAltitude(int altitudeValue){
		this.altitude = altitude;
	}

	@Override
	public void rideBicycle() {
		super.rideBicycle();
	}

	@Override
	public String toString() {
		return "MountainBicycle [altitude=" + altitude + ", gear=" + gear
				+ ", speed=" + speed + ", cadance=" + cadance + "]";
	}
}
