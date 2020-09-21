#include "calculatorlogic.h"
#include "string.h"
#include "qvariant.h"
#include "math.h"
#include "qstack.h"

CalculatorLogic::CalculatorLogic(QObject *parent) : QObject(parent)
{
    _trenutniRezultat = "-1";
}

QString CalculatorLogic::trenutniRezultat() const
{
    return _trenutniRezultat;
}

void CalculatorLogic::setTrenutniRezultat(QString x)
{
    if (_trenutniRezultat == x)
        return;

    _trenutniRezultat = x;
    emit resultChanged(x);
}

void CalculatorLogic::doCommand(QString str)
{
    if (str == "C")
    {
        setTrenutniRezultat("");
        _trenutniRezultat = "";
    }
    else if (str == "↵")
        setTrenutniRezultat(_trenutniRezultat.left(_trenutniRezultat.length() - 1));
    else if (str == "∓")
        setTrenutniRezultat(_trenutniRezultat + "*(-1)");
    else if (str == "√")
        setTrenutniRezultat(_trenutniRezultat + "sqrt");
    else if (str == "=")
    {
        double res = izracunaj(_trenutniRezultat);
        QString result = QString::number(res);

        emit resultHistoryChanged(_trenutniRezultat + '=' + result);
    }
    else
        setTrenutniRezultat(_trenutniRezultat + str);
}

void CalculatorLogic::onBtnClicked()
{
    QString operation = sender()->property("text").toString();
    doCommand(operation);
}

int CalculatorLogic::prioritet(QChar op){
    if(op == '+'||op == '-')
    return 1;
    if(op == '*'||op == '/')
    return 2;
    return 0;
}

double CalculatorLogic::uradiOp(double a, double b, QChar op){
    if (op == '+')
        return a + b;
    else if (op == '-')
        return a - b;
    else if (op == '*')
        return a * b;
    else if (op == '/')
        return a / b;
    else if (op == 's')
        return sqrt(a);
}

double CalculatorLogic::izracunaj(QString karakteri){
    int i;

    QStack<double> vrednosti;
    QStack<QChar> op;

    for(i = 0; i < karakteri.length(); i++)
    {
        if(karakteri[i].isDigit())
        {
            QString val = "";

            while(i < karakteri.length() && ((karakteri[i].isDigit()) || (karakteri[i] == '.')))
            {
                val.append(karakteri[i]);
                i++;
            }

            i--;
            bool ok = false;
            vrednosti.push(val.toDouble(&ok));
        }
        else
        {
            // poseban slucaj menjanja znaka
            if ((karakteri[i] == '*') && (karakteri[i+1] == '('))
            {
                double tmp = vrednosti.top();
                tmp = tmp * (-1);
                vrednosti.pop();
                vrednosti.push(tmp);

                i = i + 4;
                continue;
            }

            // poseban slucaj za korenovanje
            if (karakteri[i] == 's')
            {
                i = i + 4;

                QString val = "";
                while(i < karakteri.length() && ((karakteri[i].isDigit()) || (karakteri[i] == '.')))
                {
                    val.append(karakteri[i]);
                    i++;
                }

                i--;
                bool ok = false;
                double broj = val.toDouble(&ok);

                vrednosti.push(uradiOp(broj, -1, 's'));
                continue;
            }

            while(!op.empty() && prioritet(op.top()) >= prioritet(karakteri[i]))
            {
                double val2 = vrednosti.top();
                vrednosti.pop();

                double val1 = vrednosti.top();
                vrednosti.pop();

                QChar operacija = op.top();
                op.pop();

                vrednosti.push(uradiOp(val1, val2, operacija));
            }

            op.push(karakteri[i]);
        }
    }

    while(!op.empty()){
        double val2 = vrednosti.top();
        vrednosti.pop();

        double val1 = vrednosti.top();
        vrednosti.pop();

        QChar operacija = op.top();
        op.pop();

        vrednosti.push(uradiOp(val1, val2, operacija));
    }

    return vrednosti.top();
}
