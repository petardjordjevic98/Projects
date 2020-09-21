/********************************************************************************
** Form generated from reading UI file 'calculatormain.ui'
**
** Created by: Qt User Interface Compiler version 5.13.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CALCULATORMAIN_H
#define UI_CALCULATORMAIN_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPlainTextEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CalculatorMain
{
public:
    QHBoxLayout *horizontalLayout_2;
    QGridLayout *gridLayout;
    QGridLayout *gridLayout_3;
    QPushButton *pushButtonBackspace;
    QPushButton *pushButton1;
    QPushButton *pushButton5;
    QPushButton *pushButton2;
    QPushButton *pushButton3;
    QPushButton *pushButtonPlus;
    QPushButton *pushButtonPuta;
    QPushButton *pushButtonTacka;
    QPushButton *pushButton0;
    QPushButton *pushButton8;
    QPushButton *pushButtonKoren;
    QPushButton *pushButton9;
    QPushButton *pushButtonMinus;
    QPushButton *pushButton4;
    QPushButton *pushButtonPodeljeno;
    QPushButton *pushButtonJednako;
    QPushButton *pushButton7;
    QPushButton *pushButtonC;
    QPushButton *pushButton6;
    QPushButton *pushButtonZnak;
    QLineEdit *lineEditDisplej;
    QVBoxLayout *verticalLayout;
    QPlainTextEdit *plainTextEditIstroija;

    void setupUi(QWidget *CalculatorMain)
    {
        if (CalculatorMain->objectName().isEmpty())
            CalculatorMain->setObjectName(QString::fromUtf8("CalculatorMain"));
        CalculatorMain->resize(829, 501);
        horizontalLayout_2 = new QHBoxLayout(CalculatorMain);
        horizontalLayout_2->setObjectName(QString::fromUtf8("horizontalLayout_2"));
        gridLayout = new QGridLayout();
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        gridLayout->setSizeConstraint(QLayout::SetDefaultConstraint);
        gridLayout_3 = new QGridLayout();
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        gridLayout_3->setSizeConstraint(QLayout::SetMinAndMaxSize);
        pushButtonBackspace = new QPushButton(CalculatorMain);
        pushButtonBackspace->setObjectName(QString::fromUtf8("pushButtonBackspace"));
        QSizePolicy sizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(pushButtonBackspace->sizePolicy().hasHeightForWidth());
        pushButtonBackspace->setSizePolicy(sizePolicy);
        QFont font;
        font.setPointSize(15);
        pushButtonBackspace->setFont(font);

        gridLayout_3->addWidget(pushButtonBackspace, 2, 4, 1, 1);

        pushButton1 = new QPushButton(CalculatorMain);
        pushButton1->setObjectName(QString::fromUtf8("pushButton1"));
        sizePolicy.setHeightForWidth(pushButton1->sizePolicy().hasHeightForWidth());
        pushButton1->setSizePolicy(sizePolicy);
        QFont font1;
        font1.setPointSize(12);
        pushButton1->setFont(font1);

        gridLayout_3->addWidget(pushButton1, 3, 0, 1, 1);

        pushButton5 = new QPushButton(CalculatorMain);
        pushButton5->setObjectName(QString::fromUtf8("pushButton5"));
        sizePolicy.setHeightForWidth(pushButton5->sizePolicy().hasHeightForWidth());
        pushButton5->setSizePolicy(sizePolicy);
        pushButton5->setFont(font1);

        gridLayout_3->addWidget(pushButton5, 2, 1, 1, 1);

        pushButton2 = new QPushButton(CalculatorMain);
        pushButton2->setObjectName(QString::fromUtf8("pushButton2"));
        sizePolicy.setHeightForWidth(pushButton2->sizePolicy().hasHeightForWidth());
        pushButton2->setSizePolicy(sizePolicy);
        pushButton2->setFont(font1);

        gridLayout_3->addWidget(pushButton2, 3, 1, 1, 1);

        pushButton3 = new QPushButton(CalculatorMain);
        pushButton3->setObjectName(QString::fromUtf8("pushButton3"));
        sizePolicy.setHeightForWidth(pushButton3->sizePolicy().hasHeightForWidth());
        pushButton3->setSizePolicy(sizePolicy);
        pushButton3->setFont(font1);

        gridLayout_3->addWidget(pushButton3, 3, 2, 1, 1);

        pushButtonPlus = new QPushButton(CalculatorMain);
        pushButtonPlus->setObjectName(QString::fromUtf8("pushButtonPlus"));
        sizePolicy.setHeightForWidth(pushButtonPlus->sizePolicy().hasHeightForWidth());
        pushButtonPlus->setSizePolicy(sizePolicy);
        pushButtonPlus->setFont(font1);

        gridLayout_3->addWidget(pushButtonPlus, 4, 2, 1, 1);

        pushButtonPuta = new QPushButton(CalculatorMain);
        pushButtonPuta->setObjectName(QString::fromUtf8("pushButtonPuta"));
        sizePolicy.setHeightForWidth(pushButtonPuta->sizePolicy().hasHeightForWidth());
        pushButtonPuta->setSizePolicy(sizePolicy);
        pushButtonPuta->setFont(font1);

        gridLayout_3->addWidget(pushButtonPuta, 2, 3, 1, 1);

        pushButtonTacka = new QPushButton(CalculatorMain);
        pushButtonTacka->setObjectName(QString::fromUtf8("pushButtonTacka"));
        sizePolicy.setHeightForWidth(pushButtonTacka->sizePolicy().hasHeightForWidth());
        pushButtonTacka->setSizePolicy(sizePolicy);
        pushButtonTacka->setFont(font1);

        gridLayout_3->addWidget(pushButtonTacka, 4, 1, 1, 1);

        pushButton0 = new QPushButton(CalculatorMain);
        pushButton0->setObjectName(QString::fromUtf8("pushButton0"));
        sizePolicy.setHeightForWidth(pushButton0->sizePolicy().hasHeightForWidth());
        pushButton0->setSizePolicy(sizePolicy);
        pushButton0->setFont(font1);

        gridLayout_3->addWidget(pushButton0, 4, 0, 1, 1);

        pushButton8 = new QPushButton(CalculatorMain);
        pushButton8->setObjectName(QString::fromUtf8("pushButton8"));
        sizePolicy.setHeightForWidth(pushButton8->sizePolicy().hasHeightForWidth());
        pushButton8->setSizePolicy(sizePolicy);
        pushButton8->setFont(font1);

        gridLayout_3->addWidget(pushButton8, 1, 1, 1, 1);

        pushButtonKoren = new QPushButton(CalculatorMain);
        pushButtonKoren->setObjectName(QString::fromUtf8("pushButtonKoren"));
        sizePolicy.setHeightForWidth(pushButtonKoren->sizePolicy().hasHeightForWidth());
        pushButtonKoren->setSizePolicy(sizePolicy);
        pushButtonKoren->setFont(font1);

        gridLayout_3->addWidget(pushButtonKoren, 4, 4, 1, 1);

        pushButton9 = new QPushButton(CalculatorMain);
        pushButton9->setObjectName(QString::fromUtf8("pushButton9"));
        sizePolicy.setHeightForWidth(pushButton9->sizePolicy().hasHeightForWidth());
        pushButton9->setSizePolicy(sizePolicy);
        pushButton9->setFont(font1);

        gridLayout_3->addWidget(pushButton9, 1, 2, 1, 1);

        pushButtonMinus = new QPushButton(CalculatorMain);
        pushButtonMinus->setObjectName(QString::fromUtf8("pushButtonMinus"));
        sizePolicy.setHeightForWidth(pushButtonMinus->sizePolicy().hasHeightForWidth());
        pushButtonMinus->setSizePolicy(sizePolicy);
        pushButtonMinus->setFont(font1);

        gridLayout_3->addWidget(pushButtonMinus, 3, 3, 1, 1);

        pushButton4 = new QPushButton(CalculatorMain);
        pushButton4->setObjectName(QString::fromUtf8("pushButton4"));
        sizePolicy.setHeightForWidth(pushButton4->sizePolicy().hasHeightForWidth());
        pushButton4->setSizePolicy(sizePolicy);
        pushButton4->setFont(font1);

        gridLayout_3->addWidget(pushButton4, 2, 0, 1, 1);

        pushButtonPodeljeno = new QPushButton(CalculatorMain);
        pushButtonPodeljeno->setObjectName(QString::fromUtf8("pushButtonPodeljeno"));
        sizePolicy.setHeightForWidth(pushButtonPodeljeno->sizePolicy().hasHeightForWidth());
        pushButtonPodeljeno->setSizePolicy(sizePolicy);
        pushButtonPodeljeno->setFont(font1);

        gridLayout_3->addWidget(pushButtonPodeljeno, 1, 3, 1, 1);

        pushButtonJednako = new QPushButton(CalculatorMain);
        pushButtonJednako->setObjectName(QString::fromUtf8("pushButtonJednako"));
        sizePolicy.setHeightForWidth(pushButtonJednako->sizePolicy().hasHeightForWidth());
        pushButtonJednako->setSizePolicy(sizePolicy);
        pushButtonJednako->setFont(font1);

        gridLayout_3->addWidget(pushButtonJednako, 4, 3, 1, 1);

        pushButton7 = new QPushButton(CalculatorMain);
        pushButton7->setObjectName(QString::fromUtf8("pushButton7"));
        sizePolicy.setHeightForWidth(pushButton7->sizePolicy().hasHeightForWidth());
        pushButton7->setSizePolicy(sizePolicy);
        pushButton7->setFont(font1);

        gridLayout_3->addWidget(pushButton7, 1, 0, 1, 1);

        pushButtonC = new QPushButton(CalculatorMain);
        pushButtonC->setObjectName(QString::fromUtf8("pushButtonC"));
        sizePolicy.setHeightForWidth(pushButtonC->sizePolicy().hasHeightForWidth());
        pushButtonC->setSizePolicy(sizePolicy);
        pushButtonC->setFont(font1);

        gridLayout_3->addWidget(pushButtonC, 1, 4, 1, 1);

        pushButton6 = new QPushButton(CalculatorMain);
        pushButton6->setObjectName(QString::fromUtf8("pushButton6"));
        sizePolicy.setHeightForWidth(pushButton6->sizePolicy().hasHeightForWidth());
        pushButton6->setSizePolicy(sizePolicy);
        pushButton6->setFont(font1);

        gridLayout_3->addWidget(pushButton6, 2, 2, 1, 1);

        pushButtonZnak = new QPushButton(CalculatorMain);
        pushButtonZnak->setObjectName(QString::fromUtf8("pushButtonZnak"));
        sizePolicy.setHeightForWidth(pushButtonZnak->sizePolicy().hasHeightForWidth());
        pushButtonZnak->setSizePolicy(sizePolicy);
        pushButtonZnak->setFont(font1);

        gridLayout_3->addWidget(pushButtonZnak, 3, 4, 1, 1);

        lineEditDisplej = new QLineEdit(CalculatorMain);
        lineEditDisplej->setObjectName(QString::fromUtf8("lineEditDisplej"));
        QSizePolicy sizePolicy1(QSizePolicy::Minimum, QSizePolicy::Fixed);
        sizePolicy1.setHorizontalStretch(0);
        sizePolicy1.setVerticalStretch(0);
        sizePolicy1.setHeightForWidth(lineEditDisplej->sizePolicy().hasHeightForWidth());
        lineEditDisplej->setSizePolicy(sizePolicy1);
        lineEditDisplej->setMinimumSize(QSize(0, 100));
        lineEditDisplej->setBaseSize(QSize(0, 100));
        QFont font2;
        font2.setPointSize(14);
        lineEditDisplej->setFont(font2);
        lineEditDisplej->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        lineEditDisplej->setReadOnly(true);

        gridLayout_3->addWidget(lineEditDisplej, 0, 0, 1, 5);


        gridLayout->addLayout(gridLayout_3, 0, 0, 1, 1);

        verticalLayout = new QVBoxLayout();
        verticalLayout->setObjectName(QString::fromUtf8("verticalLayout"));
        verticalLayout->setSizeConstraint(QLayout::SetMaximumSize);
        plainTextEditIstroija = new QPlainTextEdit(CalculatorMain);
        plainTextEditIstroija->setObjectName(QString::fromUtf8("plainTextEditIstroija"));
        sizePolicy.setHeightForWidth(plainTextEditIstroija->sizePolicy().hasHeightForWidth());
        plainTextEditIstroija->setSizePolicy(sizePolicy);
        plainTextEditIstroija->setMinimumSize(QSize(400, 0));
        plainTextEditIstroija->setFont(font2);
        plainTextEditIstroija->setReadOnly(true);

        verticalLayout->addWidget(plainTextEditIstroija);


        gridLayout->addLayout(verticalLayout, 0, 1, 1, 1);


        horizontalLayout_2->addLayout(gridLayout);

        QWidget::setTabOrder(lineEditDisplej, pushButton7);
        QWidget::setTabOrder(pushButton7, pushButton8);
        QWidget::setTabOrder(pushButton8, pushButton9);
        QWidget::setTabOrder(pushButton9, pushButtonPodeljeno);
        QWidget::setTabOrder(pushButtonPodeljeno, pushButtonC);
        QWidget::setTabOrder(pushButtonC, pushButton4);
        QWidget::setTabOrder(pushButton4, pushButton5);
        QWidget::setTabOrder(pushButton5, pushButton6);
        QWidget::setTabOrder(pushButton6, pushButtonPuta);
        QWidget::setTabOrder(pushButtonPuta, pushButtonBackspace);
        QWidget::setTabOrder(pushButtonBackspace, pushButton1);
        QWidget::setTabOrder(pushButton1, pushButton2);
        QWidget::setTabOrder(pushButton2, pushButton3);
        QWidget::setTabOrder(pushButton3, pushButtonMinus);
        QWidget::setTabOrder(pushButtonMinus, pushButtonZnak);
        QWidget::setTabOrder(pushButtonZnak, pushButton0);
        QWidget::setTabOrder(pushButton0, pushButtonTacka);
        QWidget::setTabOrder(pushButtonTacka, pushButtonPlus);
        QWidget::setTabOrder(pushButtonPlus, pushButtonJednako);
        QWidget::setTabOrder(pushButtonJednako, pushButtonKoren);
        QWidget::setTabOrder(pushButtonKoren, plainTextEditIstroija);

        retranslateUi(CalculatorMain);

        QMetaObject::connectSlotsByName(CalculatorMain);
    } // setupUi

    void retranslateUi(QWidget *CalculatorMain)
    {
        CalculatorMain->setWindowTitle(QCoreApplication::translate("CalculatorMain", "CalculatorMain", nullptr));
        pushButtonBackspace->setText(QCoreApplication::translate("CalculatorMain", "\342\206\265", nullptr));
        pushButton1->setText(QCoreApplication::translate("CalculatorMain", "1", nullptr));
        pushButton5->setText(QCoreApplication::translate("CalculatorMain", "5", nullptr));
        pushButton2->setText(QCoreApplication::translate("CalculatorMain", "2", nullptr));
        pushButton3->setText(QCoreApplication::translate("CalculatorMain", "3", nullptr));
        pushButtonPlus->setText(QCoreApplication::translate("CalculatorMain", "+", nullptr));
        pushButtonPuta->setText(QCoreApplication::translate("CalculatorMain", "*", nullptr));
        pushButtonTacka->setText(QCoreApplication::translate("CalculatorMain", ".", nullptr));
        pushButton0->setText(QCoreApplication::translate("CalculatorMain", "0", nullptr));
        pushButton8->setText(QCoreApplication::translate("CalculatorMain", "8", nullptr));
        pushButtonKoren->setText(QCoreApplication::translate("CalculatorMain", "\342\210\232", nullptr));
        pushButton9->setText(QCoreApplication::translate("CalculatorMain", "9", nullptr));
        pushButtonMinus->setText(QCoreApplication::translate("CalculatorMain", "-", nullptr));
        pushButton4->setText(QCoreApplication::translate("CalculatorMain", "4", nullptr));
        pushButtonPodeljeno->setText(QCoreApplication::translate("CalculatorMain", "/", nullptr));
        pushButtonJednako->setText(QCoreApplication::translate("CalculatorMain", "=", nullptr));
        pushButton7->setText(QCoreApplication::translate("CalculatorMain", "7", nullptr));
        pushButtonC->setText(QCoreApplication::translate("CalculatorMain", "C", nullptr));
        pushButton6->setText(QCoreApplication::translate("CalculatorMain", "6", nullptr));
        pushButtonZnak->setText(QCoreApplication::translate("CalculatorMain", "\342\210\223", nullptr));
    } // retranslateUi

};

namespace Ui {
    class CalculatorMain: public Ui_CalculatorMain {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CALCULATORMAIN_H
