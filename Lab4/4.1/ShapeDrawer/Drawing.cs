using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer

{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }
        public Drawing() : this(Color.White)
        {
            // other steps could go here…
        }
        public int ShapeCount
        {
            get 
            { 
                return _shapes.Count; 
            }
        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void SelectedShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Select = true;
                }
                else
                {
                    s.Select = false;
                }
            }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result;
                result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Select == true)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);

            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

    }
}
