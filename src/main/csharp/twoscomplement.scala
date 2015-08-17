package scala.interview

object TwosComplement {

	def getIntComplement(x: Int): Int = {
		var result: Int = 0
		var mask: Int = 1
		var max: Int = ~(Int.MaxValue >> 1)

		while(mask <= max) {
			result = ~(mask & tmp)
			mask = mask << 1
		}

		result
	}

}

