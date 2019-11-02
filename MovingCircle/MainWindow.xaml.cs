using MovingCircle.MathPrim;
using MovingCircle.Phis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovingCircle {
    
    public partial class MainWindow : Window {

        private ParticleWorld _world1 = new ParticleWorld(300, 16);
        private Particlef _particle1 = new Particlef(new Vec3f(100.0f, 100.0f, 0.0f), new Vec3f(100.0f, 0.0f, 0.0f), 16.0f, 10.0f);
        private Particlef _particle2 = new Particlef(new Vec3f(248.0f, 100.0f, 0.0f), new Vec3f(-100.0f, 0.0f, 0.0f), 16.0f, 10.0f);
        private Particlef _particle3 = new Particlef(new Vec3f(348.0f, 200.0f, 0.0f), new Vec3f(-130.0f, 0.0f, 0.0f), 16.0f, 10.0f);
        private Particlef _particle4 = new Particlef(new Vec3f(48.0f, 160.0f, 0.0f), new Vec3f(80.0f, 0.0f, 0.0f), 16.0f, 10.0f);
        private Particlef _particleUser = new Particlef(new Vec3f(48.0f, 360.0f, 0.0f), new Vec3f(0.0f, 0.0f, 0.0f), 16.0f, 10.0f);
        private ParticleGravity _g = new ParticleGravity(new Vec3f(0.0f, 9.8f * 40.0f, 0.0f));
        private UserForce _u = new UserForce();
        private GroundContact _groundContactGenerator = new GroundContact(640.0f, 480.0f);
        private SphereContact _sphereContactGenerator = new SphereContact();
        private GameTimer _timer = new GameTimer();

        public MainWindow() {
            InitializeComponent();

            _timer.reset();

            _world1.getParticles().Add(_particle1);
            _world1.getParticles().Add(_particle2);
            _world1.getParticles().Add(_particle3);
            _world1.getParticles().Add(_particle4);
            _world1.getParticles().Add(_particleUser);

            _groundContactGenerator.init(_world1.getParticles());
            _sphereContactGenerator.init(_world1.getParticles());

            _world1.getForceRegistry().add(_particle1, _g);
            _world1.getForceRegistry().add(_particle2, _g);
            _world1.getForceRegistry().add(_particle3, _g);
            _world1.getForceRegistry().add(_particle4, _g);
            _world1.getForceRegistry().add(_particleUser, _g);
            _world1.getForceRegistry().add(_particleUser, _u);

            _world1.getContactGenerators().Add(_groundContactGenerator);
            _world1.getContactGenerators().Add(_sphereContactGenerator);


            _timer.start();

            CompositionTarget.Rendering += UpdateChildren;
        }

        private void Canvas_Initialized(object sender, EventArgs e) {

        }

        protected void UpdateChildren(object sender, EventArgs e) {

            _timer.tick();

            _world1.startFrame();
            float duration = _timer.deltaTime();
            _world1.runPhysics(duration);

            Canvas.SetLeft(ParticleEllipse, _particle1.Position.x);
            Canvas.SetTop(ParticleEllipse, _particle1.Position.y);

            Canvas.SetLeft(ParticleEllipse2, _particle2.Position.x);
            Canvas.SetTop(ParticleEllipse2, _particle2.Position.y);

            Canvas.SetLeft(ParticleEllipse3, _particle3.Position.x);
            Canvas.SetTop(ParticleEllipse3, _particle3.Position.y);

            Canvas.SetLeft(ParticleEllipse4, _particle4.Position.x);
            Canvas.SetTop(ParticleEllipse4, _particle4.Position.y);

            Canvas.SetLeft(ParticleEllipseUser, _particleUser.Position.x);
            Canvas.SetTop(ParticleEllipseUser, _particleUser.Position.y);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {

            if (e.Key == Key.Escape) {
                this.Close();
            }
        }
    }
}
