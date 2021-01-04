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
                change_size(_n+1);

            if (_n <= _size && masShape[_n] == null)
            {
                masShape[_n] = b;
                _n++;
                change_size(_size+_n);
            }
        }
        public void adding(Shape b, int i)
        {
            if (_n >= _size)
                change_size(_n + 1);

            if (_n <=_size && masShape[i] == null)
            {
                masShape[i] = b;
                _n++;
                change_size(_size + _n);
            }
        }

        public Shape get_Shape(int i)
        {
            if ((i < -1) || (i > _size))
            {
                return default(Shape);
            }
            else
         
            {
                return masShape[i];
            }
        }

        public void change_size(int newSize)
        {
            Shape[] masShape1 = new Shape[newSize];
            int size = _size < newSize ? _size : newSize;
            for (int i = 0; i < size; i++)
            {
                masShape1[i] = masShape[i];
            }
            masShape = masShape1;
            _size = newSize;
        }

        public void delete_Shape(int i)
        {
            if (masShape[i] != null)
            {
                _n--;
                //change_size(_n);
            }
            masShape[i] = default(Shape);
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


        public Storage(Storage<Shape> a)
        {
            _n = a._n;
            _size = a._size;
            for (int i = 0; i < _size; i++)
            {
                masShape[i] = a.masShape[i];
            }
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
