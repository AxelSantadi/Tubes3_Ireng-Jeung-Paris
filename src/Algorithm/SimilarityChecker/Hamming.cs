
namespace Algorithm {
public static class Hamming {
	public static int Distance(string a, string b) {
		if (a.Length != b.Length) {
			throw new ArgumentException("Strings must be of equal length");
		}

		int distance = 0;
		for (int i = 0; i < a.Length; i++) {
			if (a[i] != b[i]) {
				distance++;
			}
		}

		return distance;
	}

	public static double Similarity(string a, string b) {
		if (a.Length != b.Length) {
			throw new ArgumentException("Strings must be of equal length");
		} else {
			int distance = Distance(a, b);
			return (1 - (double)distance / a.Length) * 100;
		}
	}
}
}