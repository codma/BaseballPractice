using System;
using System.Collections.Generic;

namespace Baseball
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();

            int randomNum;
            List<int> baseBall = new List<int>();


            // 1. 포문이 첫번째 실행 계획이다. i = 0
            // 2. 랜덤넘에 1~9사이의 숫자를 랜덤으로 랜덤넘에 저장함
            // 3. 만약에~ baseball list에 아무것도 들어있지 않가? 그러면 2번 랜넘덤의 임의 숫자를 베이스볼 리스트에 추가한다.
            // 4. 이후 코드는 컨너뛰고 다시 포문을 돌린다(continue)
            // 5. 포문이 두번째 실행 계획이ㄷ. i = 1
            // 6. 랜덤넘에 1~9사이의 숫자를 랜덤으로 랜덤넘에 저장함
            // 7. 만약에 ~ 3번을 체크하는데, 이미 있어요. 다음 if인 랜덤넘이 포함되어있는지를 체크한다.
            // 8. 이때, 랜덤넘이 처음 들어왔던 숫자인지 아닌지 모름.
            // 9. 두번째 이프 설명 - 랜덤넘이 포함되어있다 (첫번째 넣었던 숫자랑 같다)
            // 10 그러면 i의 차수(?)를 -1 해서 포문을 돌린다 i = 0
            // 10-1 포문이 다시 돈다~ 돌기만 하면 i++ 가 작동해서 i = 1 즉 5번의 상황으로 감.
            // 10-2 i = 2가 될때까지 돌림~ 중복이 안되도록 계속 돌아감.
            // 11. 랜덤넘이 포함되어있지 않았다?(첫번째 넣었던 숫자랑 다르다) i = 1
            // 12. 새로운 랜덤넘을 베이스볼리스트에 추가

            for (int i = 0; i < 3; i++)
            {
                randomNum = rand.Next(1, 9);
                //randomNum 1~9사이 숫자를 랜덤으로 반환

                if (baseBall.Count == 0)
                //최초 등록. 카운트가 0이면 아무 숫자도 들어가 있지 않다는 것
                {
                    baseBall.Add(randomNum);
                    // 리스트에 랜덤넘버를 추가
                    continue;
                }
                if (baseBall.Contains(randomNum))
                //뭐가 들어있으면
                {
                    i--;
                    //반복 횟수를 초기화 해라
                    continue;
                }
                baseBall.Add(randomNum);
            }


            for (; ; )
            {
                List<int> inputNums = new List<int>();

                Console.WriteLine("첫번째 숫자를 입력해주세요");
                inputNums.Add(int.Parse(Console.ReadLine()));
                //int.Parse : 스트링을 int 로 변환(구글링키워드는 int to string)
                //.ToString  : ~형식을 str로 변환

                Console.WriteLine("두번째 숫자를 입력해주세요");
                inputNums.Add(int.Parse(Console.ReadLine()));

                Console.WriteLine("세번째 숫자를 입력해주세요");
                inputNums.Add(int.Parse(Console.ReadLine()));



                //1. 스트라이크와 볼은 0부터 시작한다.
                int strike = 0;
                int ball = 0;

                //2, 인풋넘에 있는 3개 숫자와 베이스볼에 있는 3개 숫자를 비교하기 시작한다.
                //3. for ~~ if 베이스볼[i] == 인풋넘[i], 스트라이크 1추가 >>스트라이크는 끝
                for (int i = 0; i < baseBall.Count; i++)
                {
                    if (baseBall[i] == inputNums[i])
                    {
                        strike++;
                        continue;
                    }
                }

                //3-1 만약에 스트라이크가 3이면 return 게임끝 말 써주기
                if (strike == 3)
                {
                    Console.WriteLine("3 Strike!!!! 게임 끝!!");
                    return;
                    //프로그램 끝
                }

                //3-2 스트라이크가 3이 아니면 4번으로 넘어가기(엘스를 써도되고 안써도됨. 스트라이크 3이 아니기 때문에 계속 진행됨)
                else
                {
                    //4. 볼을 찾기 위해 포문을 돌리는데, i는 베이스볼의 인덱스, j 인풋넘의 인덱스.
                    for (int i = 0; i < baseBall.Count; i++)
                    {
                        for (int j = 0; j < inputNums.Count; j++)
                        {
                            //5. i == j 이말은, i의 인덱스와 j 인덱스가 같은 자리이다.
                            //6. baseBall의 값이 InputNums 값과 같으면서 인덱스가 서로 다른
                            if (i != j && baseBall[i] == inputNums[j])
                            {

                                //7. for~ if 인풋넘.컨테인(베이스볼) 이면서, i != j 이면 볼추가
                                ball++;
                            }
                        }
                    }
                    Console.WriteLine(strike + "strike " + ball + "ball");
                }
            }
        }
    }
}

