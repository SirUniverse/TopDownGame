﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    abstract class Character
    {
        protected Character(Level Level, int Xposition, int Yposition, ConsoleColor Color)
        {
            _level = Level;
            _level.Characters.Add(this);
            _xPos = Xposition;
            _yPos = Yposition;
            _oxPos = Xposition;
            _oyPos = Yposition;
            _color = Color;
        }

        #region Properties

        public Level Level
        {
            get { return _level; }
        }

        public int Xpos
        {
            get { return _xPos; }
            protected set { _xPos = value;}
        }

        public int Ypos
        {
            get { return _yPos; }
            protected set { _yPos = value; }
        }

        public int Xorient
        {
            get { return _oxPos; }
            protected set { _oxPos = value; }
        }

        public int Yorient
        {
            get { return _oyPos; }
            protected set { _oyPos = value; }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            protected set { _color = value; }
        }

        public char Sprite
        {
            get { return _sprite; }
            protected set { _sprite = value; }
        }

        #endregion

        public void Update()
        {
            ExecuteBehaviour();
        }

        protected abstract void ExecuteBehaviour();

        public void Draw()
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.Write(_sprite);
            Console.ForegroundColor = aux;
        }

        protected void Move(Direction Direction)
        {
            switch(Direction)
            {
                case Direction.Up:
                    if (!_level.CheckCollision(_xPos, _yPos - 1))
                        --_yPos;
                    _oyPos = _yPos - 1;
                    _oxPos = _xPos;
                    break;
                case Direction.Down:
                    if (!_level.CheckCollision(_xPos, _yPos + 1))
                        ++_yPos;
                    _oyPos = _yPos + 1;
                    _oxPos = _xPos;
                    break;
                case Direction.Left:
                    if (!_level.CheckCollision(_xPos - 1, _yPos))
                        --_xPos;
                    _oxPos = _xPos - 1;
                    _oyPos = _yPos;
                    break;
                case Direction.Right:
                    if (!_level.CheckCollision(_xPos + 1, _yPos))
                        ++_xPos;
                    _oxPos = _xPos + 1;
                    _oyPos = _yPos;
                    break;
                default: break;
            }
        }

        #region Fields

        private Level _level;
        private int _xPos, _yPos, _oxPos, _oyPos;
        private ConsoleColor _color;
        private char _sprite;

        #endregion
    }
}
