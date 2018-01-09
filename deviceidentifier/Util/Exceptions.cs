using System;

namespace Reincubate.DeviceIdentifier.Util {

    public class InvalidIdentifierException: Exception {
        public InvalidIdentifierException() {
        }

        public InvalidIdentifierException(string message) : base(message) {
        }

        public InvalidIdentifierException(string message, Exception inner)
            : base(message, inner) {
        }
    }

    public class InvalidTokenException: Exception {
        public InvalidTokenException() {
        }

        public InvalidTokenException(string message) : base(message) {
        }

        public InvalidTokenException(string message, Exception inner)
            : base(message, inner) {
        }
    }

    public class ExpiredTokenException: Exception {
        public ExpiredTokenException() {
        }

        public ExpiredTokenException(string message) : base(message) {
        }

        public ExpiredTokenException(string message, Exception inner)
            : base(message, inner) {
        }
    }

    public class BadRequestException: Exception {
        public BadRequestException() {
        }

        public BadRequestException(string message) : base(message) {
        }

        public BadRequestException(string message, Exception inner)
            : base(message, inner) {
        }
    }

    public class UnhandledException: Exception {
        public UnhandledException() {
        }

        public UnhandledException(string message) : base(message) {
        }

        public UnhandledException(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
