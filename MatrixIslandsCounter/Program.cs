using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixIslandsCounter {

    class Program {

        const int iMatrixSize = 15; // size of matrix [X,Y]

        static int[,] myMatrix = new int[iMatrixSize, iMatrixSize];

        static int iIslandNumber; // used to name each matrix element in FindIslandsInMatrix

        static int numberOfIslands; // the count of how many islands found

        const int iIsolatingWallNumber = 9; // the symbol that separate islands


        static void Main(string[] args) {

            // to debug and test
            // separate some parts of matrix to can see it working
            //--------------------
            for (int i = 0; i < 8; i++) {
                myMatrix[i, 7] = iIsolatingWallNumber;
            }
            for (int i = 0; i < 8; i++) {
                myMatrix[i, 12] = iIsolatingWallNumber;
            }

            for (int i = 7; i < 13; i++) {
                myMatrix[8, i] = iIsolatingWallNumber;
            }

            //myMatrix[0, 12] = 0; // comment and uncomment to test
            //--------------------

            // to debug and test
            //visualize raw matrix
            //--------------------
            for (int x = 0; x < iMatrixSize; x++) {
                for (int y = 0; y < iMatrixSize; y++) {
                    Console.Write(myMatrix[x, y].ToString() + "  ");
                }
                Console.WriteLine();
            }
            //--------------------

            // call the method to make its work
            //----------------------------------------------------------
            FindIslandsInMatrix();
            //----------------------------------------------------------

            // to debug and test
            // visualize original matrix changed by last method
            //--------------------
            Console.WriteLine();
            Console.WriteLine();

            for (int x = 0; x < iMatrixSize; x++) {
                for (int y = 0; y < iMatrixSize; y++) {
                    Console.Write(myMatrix[x, y].ToString() + "  ");
                }
                Console.WriteLine();
            }
            //--------------------

            // getting the count of islands, subtract 1 beacuse counter started with 1
            //--------------------
            numberOfIslands = iIslandNumber - 1;
            Console.WriteLine();
            Console.WriteLine("Number of islands found in this matrix: "+ numberOfIslands.ToString());
            //--------------------

            //--------------------
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            //--------------------
        }
        // this method walks in the raw matrix looking for 0s and make island grow from the fist 0 found
        static void FindIslandsInMatrix() {
            iIslandNumber = 1; // starts in 1, because at least 1 island will exist

            for (int y = 0; y < iMatrixSize; y++) {
                for (int x = 0; x < iMatrixSize; x++) {
                    if (myMatrix[x, y] == 0) {
                        GrowIslandFromHere(x, y);
                        iIslandNumber++; // plus 1 to use in next island if it exist
                    }
                }
            }
        }
        // starts from XY given by FindIslandsInMatrix() to name each element from raw matrix 
        // to group 0-elements immediately next to other 0-elements in horizontal and vertical space
        static void GrowIslandFromHere(int x, int y) {
            int iElementVal = 0;

            if (x < iMatrixSize && y < iMatrixSize && x >= 0 && y >= 0) { // test if is out of range

                iElementVal = myMatrix[x, y]; // get the val element

                if (iElementVal != iIsolatingWallNumber) { // test if is not a wall

                    myMatrix[x, y] = iIslandNumber; // name the element with current island count number

                    // make tests with left, down, left/down, right, up and right/up immediately next element
                    // assign it too if found 0 and test if again jump 2 elements and go on again and again and again...
                    if (x - 1 >= 0) {
                        if (iElementVal == myMatrix[x - 1, y] && myMatrix[x - 1, y] != iIslandNumber) {
                            myMatrix[x - 1, y] = iIslandNumber;
                            if (x - 2 >= 0) {
                                GrowIslandFromHere(x - 2, y);
                            }
                        }
                    }
                    if (y - 1 >= 0) {
                        if (iElementVal == myMatrix[x, y - 1] && myMatrix[x, y - 1] != iIslandNumber) {
                            myMatrix[x, y - 1] = iIslandNumber;
                            if (y - 2 >= 0) {
                                GrowIslandFromHere(x, y - 2);
                            }
                        }
                    }
                    if (x - 1 >= 0 && y - 1 >= 0) {
                        if (iElementVal == myMatrix[x - 1, y - 1] && myMatrix[x - 1, y - 1] != iIslandNumber) {
                            myMatrix[x - 1, y - 1] = iIslandNumber;
                        }
                    }
                    //---

                    if (x + 1 < iMatrixSize) {
                        if (iElementVal == myMatrix[x + 1, y] && myMatrix[x + 1, y] != iIslandNumber) {
                            myMatrix[x + 1, y] = iIslandNumber;
                            if (x + 2 < iMatrixSize) {
                                GrowIslandFromHere(x + 2, y);
                            }
                        }
                    }
                    if (y + 1 < iMatrixSize) {
                        if (iElementVal == myMatrix[x, y + 1] && myMatrix[x, y + 1] != iIslandNumber) {
                            myMatrix[x, y + 1] = iIslandNumber;
                            if (y + 2 < iMatrixSize) {
                                GrowIslandFromHere(x, y + 2);
                            }
                        }
                    }
                    if (x + 1 < iMatrixSize && y + 1 < iMatrixSize) {
                        if (iElementVal == myMatrix[x + 1, y + 1] && myMatrix[x + 1, y + 1] != iIslandNumber) {
                            myMatrix[x + 1, y + 1] = iIslandNumber;
                        }
                    }
                }
            }
        }
    }
}
