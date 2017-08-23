using System;

namespace Reincubate.DeviceIdentifier.Util {

    public class MissingTokenException: Exception {

        public MissingTokenException() {
        }

        public MissingTokenException(string message) : base(message) {
        }

        public MissingTokenException(string message, Exception inner)
            : base(message, inner) {
        }
   
    }
}
