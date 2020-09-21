#ifndef CALCULATORLOGIC_H
#define CALCULATORLOGIC_H

#include <QObject>

class CalculatorLogic : public QObject
{
    Q_OBJECT
public:
    explicit CalculatorLogic(QObject *parent = nullptr);

    QString trenutniRezultat() const;        // getter

signals:
    void resultChanged(QString);
    void resultHistoryChanged(QString);

public slots:
    void setTrenutniRezultat(QString x);     // setter
    void doCommand(QString str);
    void onBtnClicked();
    int prioritet(QChar op);
    double uradiOp(double a, double b, QChar op);
    double izracunaj(QString karakteri);

private:
    QString _trenutniRezultat;
};

#endif // CALCULATORLOGIC_H
