
public class InheritanceTest {

	public static void main(String[] args) {
		Bicycle normalBike = new Bicycle(10, 213, 45);
		MountainBicycle mountainBike = new MountainBicycle(15, 215, 46, 201);

		IBicycleRide[] arr = {normalBike, mountainBike};
		
		System.out.println(normalBike);
		normalBike.rideBicycle();
		
		System.out.println(mountainBike);
		mountainBike.rideBicycle();
		
		System.out.println(arr[1]);
	}

}
