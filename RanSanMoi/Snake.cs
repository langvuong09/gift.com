using System;
namespace RanSanMoi
{
    public class Snake{
        public Snake(){
            this.Head = new Point(10, 10);
            this.Body = new List<Point>();
            this.Body.Add(new Point(-1,-1)); 
            this.Body.Add(new Point(-1,-1)); 
        }

        public Point Head { get; set; }
        public List<Point> Body { get; set; }

        private void moveBody(int aRow, int aColumn){
            //Chỉnh vị trí thân rắn
            for(int i=0;i < this.Body.Count; i++){
                int tmpRow = this.Body[i].Row;
                int tmpColumn = this.Body[i].Column;
                this.Body[i].Row = aRow;   
                this.Body[i].Column = aColumn;
                aRow = tmpRow;
                aColumn = tmpColumn;           
            }
        }

        public bool IsHeadTouchBody(){
            for(int i=0;i<this.Body.Count;i++){
                Point element = this.Body[i];
                if(element.Row == this.Head.Row && element.Column == this.Head.Column){
                    return true;
                }
            }
            return false;
        }

        public void move(string direction, int n, int m){
            if(direction == Direction.DIRECTION_RIGHT){
                
                int crtColumn = this.Head.Column;
                this.Head.Column = crtColumn + 1;

                if(this.Head.Column >= m-1){
                    this.Head.Column=1;
                }

                this.moveBody(this.Head.Row, crtColumn);
            }else if(direction == Direction.DIRECTION_LEFT){
                int crtColumn = this.Head.Column;
                this.Head.Column = crtColumn - 1;

                if(this.Head.Column <= 0){
                    this.Head.Column=m-2;
                }

                this.moveBody(this.Head.Row, crtColumn);
            }else if(direction == Direction.DIRECTION_UP){
                int crtRow = this.Head.Row;
                this.Head.Row = crtRow - 1;

                if(this.Head.Row <= 0){
                    this.Head.Row=n-2;
                }

                this.moveBody(crtRow, this.Head.Column);
            }else if(direction == Direction.DIRECTION_DOWN){
                int crtRow = this.Head.Row;
                this.Head.Row = crtRow + 1;

                if(this.Head.Row >= n-1){
                    this.Head.Row=1;
                }

                this.moveBody(crtRow, this.Head.Column);
            }
        }
    }
}