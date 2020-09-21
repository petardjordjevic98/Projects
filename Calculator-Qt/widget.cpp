#include "widget.h"
#include "ui_calculatormain.h"

CalculatorMain::CalculatorMain(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::CalculatorMain)
{
    ui->setupUi(this);
    logic = new CalculatorLogic(this);

    connect(ui->pushButton0, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton1, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton2, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton3, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton4, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton5, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton6, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton7, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton8, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButton9, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonTacka, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonPlus, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonJednako, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonMinus, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonPuta, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonPodeljeno, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonC, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonBackspace, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonZnak, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));
    connect(ui->pushButtonKoren, SIGNAL(clicked()), logic, SLOT(onBtnClicked()));

    connect(logic, SIGNAL(resultChanged(QString)), this, SLOT(onResultChanged(QString)));
    connect(logic, SIGNAL(resultHistoryChanged(QString)), this, SLOT(onResultHistoryChanged(QString)));

    logic->setTrenutniRezultat("");
}

CalculatorMain::~CalculatorMain()
{
    delete ui;
}

void CalculatorMain::onResultChanged(QString str)
{
    ui->lineEditDisplej->setText(str);
}

void  CalculatorMain::onResultHistoryChanged(QString str)
{
    ui->plainTextEditIstroija->appendPlainText(str + "\n");
    ui->lineEditDisplej->setText("");
    logic->setTrenutniRezultat("");
}
