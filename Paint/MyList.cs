using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public struct dat
    {
        public string action;
        public int x;
        public int y;
        public int width;
        public int height;
        public string color;
        public string style;
        public string text;
    }

    public class MyList
    {
        public MyList pointerNext = null;
        public MyList pointerPrivious = null;
        public  MyList head = null;
        public dat Data = new dat();

        public MyList()
        {
            pointerNext = null;
            pointerPrivious = null;
        }

        public String Print()
        {
            String res = "";
            MyList cur = head;
            if (cur != null)
            {
                while (cur.pointerNext != null && cur != null)
                {
                    if (cur != null && cur.Data.action != "")
                    {
                        res += cur.Data.action + "\r\n";
                        if (cur.Data.x != 0)
                            res += cur.Data.x + "\r\n";
                        if (cur.Data.y != 0)
                            res += cur.Data.y + "\r\n";
                        if (cur.Data.width != 0)
                            res += cur.Data.width + "\r\n";
                        if (cur.Data.height != 0)
                            res += cur.Data.height + "\r\n";
                        if (cur.Data.color != "")
                            res += cur.Data.color + "\r\n";
                        if (cur.Data.style != "")
                            res += cur.Data.style + "\r\n";
                        if (cur.Data.text != "")
                            res += cur.Data.text + "\r\n";
                    }
                    cur = cur.pointerNext;
                    if (cur == null)
                    {
                        break;
                    }
                }
                if (cur != null && cur.Data.action != "")
                {
                    res += cur.Data.action + "\r\n";
                    if (cur.Data.x != 0)
                        res += cur.Data.x + "\r\n";
                    if (cur.Data.y != 0)
                        res += cur.Data.y + "\r\n";
                    if (cur.Data.width != 0)
                        res += cur.Data.width + "\r\n";
                    if (cur.Data.height != 0)
                        res += cur.Data.height + "\r\n";
                    if (cur.Data.color != "")
                        res += cur.Data.color + "\r\n";
                    if (cur.Data.style != "")
                        res += cur.Data.style + "\r\n";
                    if (cur.Data.text != "")
                        res += cur.Data.text + "\r\n";
                }
            }
            return res;
        }

        public MyList InsertAtEnd(string action, int x, int y, int width = 0, int height = 0, string color = "", string style = "", string text = "")
        {
            MyList newItem = new MyList();
            newItem.Data.action = action;
            newItem.Data.x = x;
            newItem.Data.y = y;
            newItem.Data.width = width;
            newItem.Data.height = height;
            newItem.Data.color = color;
            newItem.Data.style = style;
            newItem.Data.text = text;
            if (head == null)
            {
                head = newItem;
                action = newItem.Data.action;
                x = newItem.Data.x;
                y = newItem.Data.y;
                height = newItem.Data.height;
                width = newItem.Data.width;
                color = newItem.Data.color;
                style = newItem.Data.style;
                text = newItem.Data.text;
                this.pointerNext = null;
                newItem.head = head;
            }
            else
            {
                if (head.pointerNext == null)
                {
                    head.pointerNext = newItem;
                }
                this.pointerNext = newItem;
                newItem.pointerPrivious = this;
                newItem.head = head;
            }
            return newItem;
        }

        public MyList undo()
        {
            MyList cur = head;
            if (cur != null)
            {
                while (cur.pointerNext != null)
                {
                    cur = cur.pointerNext;
                }
                if (cur.Data.action == "Line" && IsLineByPen(cur))
                {
                    while (cur.Data.action != "Move")
                    {
                        cur = cur.pointerPrivious;
                    }
                }
                if (cur.Data.action == "Erase")
                {
                    while (cur.Data.action != "EraseStart")
                    {
                        cur = cur.pointerPrivious;
                    }
                }
                if (cur.pointerPrivious != null)
                cur = cur.pointerPrivious;
                cur.pointerNext = null;
            }
            return cur;
        }
        
        private bool IsLineByPen(MyList cur)
        {
            while (cur.pointerPrivious != null)
            {
                if (cur.Data.action == "Move")
                {
                    return true;
                }
                else if (cur.Data.action != "Line")
                {
                    return false;
                }
                cur = cur.pointerPrivious;
            }
            return false;   
        }

        public MyList redo(MyList OldLog)//
        {
            MyList cur = head;
            MyList curOld = OldLog.head;
            if (curOld != null && cur != null)
            {

                while (cur.pointerNext != null)
                {
                    cur = cur.pointerNext;
                    curOld = curOld.pointerNext;
                }

                if (curOld.pointerNext != null)
                {
                    if (curOld.pointerNext.Data.action == "Move")
                    {
                        curOld = curOld.pointerNext;
                        while (curOld.pointerNext.Data.action == "Line")
                        {
                            cur.InsertAtEnd(curOld.Data.action, curOld.Data.x, curOld.Data.y, curOld.Data.width, curOld.Data.height,
                                curOld.Data.color, curOld.Data.style, curOld.Data.text);
                            cur = cur.pointerNext;
                            curOld = curOld.pointerNext;
                            if (curOld.pointerNext == null)
                            {
                                break;
                            }
                        }
                    }
                    else if (curOld.pointerNext.Data.action == "EraseStart")
                    {
                        curOld = curOld.pointerNext;
                        while (curOld.pointerNext.Data.action == "Erase")
                        {
                            cur.InsertAtEnd(curOld.Data.action, curOld.Data.x, curOld.Data.y, curOld.Data.width, curOld.Data.height,
                                curOld.Data.color, curOld.Data.style, curOld.Data.text);
                            cur = cur.pointerNext;
                            curOld = curOld.pointerNext;
                            if (curOld.pointerNext == null)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        curOld = curOld.pointerNext;
                    }
                }
                cur.InsertAtEnd(curOld.Data.action, curOld.Data.x, curOld.Data.y, curOld.Data.width, curOld.Data.height,
                    curOld.Data.color, curOld.Data.style, curOld.Data.text);
            }
            return cur;
        }

        public MyList ConvertToMyList(List<string> list)
        {
            MyList res = new MyList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "Move")
                {
                    res = res.InsertAtEnd("Move", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Line")
                {
                    res = res.InsertAtEnd("Line", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Pen Color")
                {
                    res = res.InsertAtEnd("Pen Color", 0, 0, 0, 0, list[++i]);
                }
                else if (list[i] == "Brush Color")
                {
                    res = res.InsertAtEnd("Brush Color", 0, 0, 0, 0, list[++i]);
                }
                else if (list[i] == "PenSize")
                {
                    res = res.InsertAtEnd("PenSize", Convert.ToInt32(list[++i]), 0);
                }
                else if (list[i] == "PenStyle")
                {
                    res = res.InsertAtEnd("PenStyle", 0, 0, 0, 0, "", list[++i]);
                }
                else if (list[i] == "BrushStyle")
                {
                    res = res.InsertAtEnd("BrushStyle", 0, 0, 0, 0, "", list[++i]);
                }
                else if (list[i] == "Rect")
                {
                    res = res.InsertAtEnd("Rect", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Ellipse")
                {
                    res = res.InsertAtEnd("Ellipse", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Font")
                {
                    res = res.InsertAtEnd("Font", 0, 0, 0, 0, "", list[++i], list[++i]);
                }
                else if (list[i] == "Text")
                {
                    res = res.InsertAtEnd("Text", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), 0, 0, "", "", list[++i]);
                }
                else if (list[i] == "Pipette")
                {
                    if (list[++i] == "Pen")
                    {
                        res = res.InsertAtEnd("Pen", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                    }
                    else
                    {
                        res = res.InsertAtEnd("Brush", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                    }
                }
                else if (list[i] == "Erase")
                {
                    res = res.InsertAtEnd("Erase", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Fill")
                {
                    res = res.InsertAtEnd("Fill", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Copy")
                {
                    res = res.InsertAtEnd("Copy", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Paste")
                {
                    res = res.InsertAtEnd("Paste", Convert.ToInt32(list[++i]), Convert.ToInt32(list[++i]));
                }
                else if (list[i] == "Clear")
                {
                    res = res.InsertAtEnd("Clear", 0, 0);
                }
                else if (list[i] == "Open")
                {
                    res = res.InsertAtEnd("Open", 0, 0, 0, 0, "", "", list[++i]);
                }
            }
            return res;
        }

        public MyList Copy(MyList inList)
        {
            MyList res = new MyList();
            MyList cur = inList.head;
            if (cur != null)
            {
                while (cur.pointerNext != null)
                {
                    res = res.InsertAtEnd(cur.Data.action, cur.Data.x, cur.Data.y, cur.Data.width, cur.Data.height, cur.Data.color, cur.Data.style, cur.Data.text);
                    cur = cur.pointerNext;
                }
                res = res.InsertAtEnd(cur.Data.action, cur.Data.x, cur.Data.y, cur.Data.width, cur.Data.height, cur.Data.color, cur.Data.style, cur.Data.text);
            }
            return res;
        }
    }
}
