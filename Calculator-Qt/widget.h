#ifndef CALCULATORMAIN_H
#define CALCULATORMAIN_H

#include <QWidget>
#include "calculatorlogic.h"

QT_BEGIN_NAMESPACE
namespace Ui { class CalculatorMain; }
QT_END_NAMESPACE

class CalculatorMain : public QWidget
{
    Q_OBJECT

public:
    CalculatorMain(QWidget *parent = nullptr);
    ~CalculatorMain();

signals:
    void clicked();

public slots:
    void onResultChanged(QString);
    void onResultHistoryChanged(QString str);



private:
    Ui::CalculatorMain *ui;
    CalculatorLogic *logic;
};
#endif // CALCULATORMAIN_H
