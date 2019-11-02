using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingCircle.MathPrim {

    public class Vec3f : IEquatable<Vec3f> {

        public float x;
        public float y;
        public float z;

        public Vec3f() {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
        }

        public Vec3f(Vec3f other) {
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
        }

        public Vec3f(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3f(float value) {
            this.x = value;
            this.y = value;
            this.z = value;
        }

        public float dot(Vec3f other) {
            return this.x * other.x + this.y * other.y + this.z * other.z;
        }

        public float len() {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public float square() {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }

        public Vec3f normalize() {
            float lenght = len();
            if (lenght > 0.0f) {
                this.x /= lenght;
                this.y /= lenght;
                this.z /= lenght;
            }
            return this;
        }

        public Vec3f normal() {
            Vec3f res = new Vec3f(this);
            float lenght = res.len();
            if (lenght > 0.0f) {
                res.x /= lenght;
                res.y /= lenght;
                res.z /= lenght;
            }
            return res;
        }

        public Vec3f unit() {
            Vec3f result = new Vec3f();
            result.x = this.x;
            result.y = this.y;
            result.z = this.z;
            result.normalize();
            return result;
        }

        public bool Equals(Vec3f other) {

            double difference_x = Math.Abs(this.x * .0001f + float.Epsilon);
            double difference_y = Math.Abs(this.y * .0001f + float.Epsilon);
            double difference_z = Math.Abs(this.z * .0001f + float.Epsilon);

            if (Math.Abs(this.x - other.x) <= difference_x && Math.Abs(this.y - other.y) <= difference_y && Math.Abs(this.z - other.z) <= difference_z) {
                return true;
            }
            else {
                return false;
            }
        }

        public float this[int i] {
            get {
                if (i == 0) return this.x;
                if (i == 1) return this.y;
                return this.z;
            }
            set {
                if (i == 0) this.x = value;
                if (i == 1) this.y = value;
                this.z = value;
            }
        }

        public static Vec3f operator +(Vec3f v1, Vec3f v2) {
            return new Vec3f(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vec3f operator -(Vec3f v1, Vec3f v2) {
            return new Vec3f(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vec3f operator *(Vec3f v1, Vec3f v2) {
            return new Vec3f(
                v1.y * v2.z - v1.z * v2.y,
                v1.z * v2.x - v1.x * v2.z,
                v1.x * v2.y - v1.y * v2.x
            );
        }

        public static Vec3f operator *(Vec3f v1, float s1) {
            return new Vec3f(v1.x * s1, v1.y * s1, v1.z * s1);
        }
    }
}
