using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingCircle
{
    public class Storage<Shape>
    {
        private int _n;//количество занятых ячеек
        public Shape[] masShape;
        public int _size;//размер
        public Storage(int size)
        {
            _n = 0;
            _size = size;
            masShape = new Shape[_size];
            for (int i = 0; i < _size; i++)
            {
                masShape[i] = default(Shape);
            }
        }

        public void add(Shape b)
        {
            if (_n >= _size)
                change_size(_n + 1);

            if (_n < _size && masShape[_n] == null)
            {
                masShape[_n] = b;
                _n++;
            }
        }

       public Shape get_Shape(int i)
        {
            if ((i > -1) && (i < _size))
            {
                return masShape[i];
            }
            else
            {
                return default;
            }
        }

        void change_size(int size)
        {
            {
                Shape[] masShape1 = new Shape[_size];
                int newsize = _size < size ? _size : size;
                for (int i = 0; i < size; i++)
                {
                    masShape1[i] = masShape[i];
                }
                masShape = masShape1;
                _size = newsize;
            }
        }

        void delete_Shape(int i)
        {
            if (masShape[i] != null)
            {
                masShape[i] = default;
                _n--;
            }
        }
        public int get_size()
        {
            return _size;
        }
        public int get_num()
        {
            return _n;
        }
        Shape next_Shape(int i)
        {
            i++;
            return masShape[i];
        }
        ~Storage()
        {
            for (int i = 0; i < _size; i++)
            {
                masShape[i] = default(Shape);
            }
        }
    }
}
