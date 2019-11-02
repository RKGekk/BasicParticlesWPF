using MovingCircle.MathPrim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingCircle.Phis {

    class GroundContact : IParticleContactGenerator {

        private List<Particlef> particles;

        public GroundContact() {
            particles = new List<Particlef>();
        }

        public void init(List<Particlef> particles) {
            this.particles = particles;
        }

        public int addContact(ParticleContact[] contacts, int current, int limit) {

            int count = 0;
            ParticleContact contact = contacts[current];
            foreach (Particlef p in particles) {

                float y = p.Position.y;
                float x = p.Position.x;
                float r = p.Radius * 2.0f;
                float w = 640.0f;
                float h = 480.0f;
                if (y + r > 480.0f) {
                    contact.contactNormal = new Vec3f(0.0f, -1.0f, 0.0f);
                    contact.particle1 = p;
                    contact.particle2 = null;
                    contact.penetration = y - h;
                    contact.restitution = 0.4f;
                    current++;
                    contact = contacts[current];
                    count++;
                }

                if (y < 0.0f) {
                    contact.contactNormal = new Vec3f(0.0f, 1.0f, 0.0f);
                    contact.particle1 = p;
                    contact.particle2 = null;
                    contact.penetration = -y - r;
                    contact.restitution = 0.4f;
                    current++;
                    contact = contacts[current];
                    count++;
                }

                if (x + r > 640.0f) {
                    contact.contactNormal = new Vec3f(-1.0f, 0.0f, 0.0f);
                    contact.particle1 = p;
                    contact.particle2 = null;
                    contact.penetration = x - w;
                    contact.restitution = 0.7f;
                    current++;
                    contact = contacts[current];
                    count++;
                }

                if (x < 0.0f) {
                    contact.contactNormal = new Vec3f(1.0f, 0.0f, 0.0f);
                    contact.particle1 = p;
                    contact.particle2 = null;
                    contact.penetration = -x - r;
                    contact.restitution = 0.4f;
                    current++;
                    contact = contacts[current];
                    count++;
                }

                if (count >= limit) return count;
            }
            return count;
        }
    }
}
