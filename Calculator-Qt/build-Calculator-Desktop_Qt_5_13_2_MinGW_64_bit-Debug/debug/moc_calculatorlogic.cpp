/****************************************************************************
** Meta object code from reading C++ file 'calculatorlogic.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.13.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include <memory>
#include "../../calculatorlogic.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'calculatorlogic.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.13.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_CalculatorLogic_t {
    QByteArrayData data[16];
    char stringdata0[146];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_CalculatorLogic_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_CalculatorLogic_t qt_meta_stringdata_CalculatorLogic = {
    {
QT_MOC_LITERAL(0, 0, 15), // "CalculatorLogic"
QT_MOC_LITERAL(1, 16, 13), // "resultChanged"
QT_MOC_LITERAL(2, 30, 0), // ""
QT_MOC_LITERAL(3, 31, 20), // "resultHistoryChanged"
QT_MOC_LITERAL(4, 52, 19), // "setTrenutniRezultat"
QT_MOC_LITERAL(5, 72, 1), // "x"
QT_MOC_LITERAL(6, 74, 9), // "doCommand"
QT_MOC_LITERAL(7, 84, 3), // "str"
QT_MOC_LITERAL(8, 88, 12), // "onBtnClicked"
QT_MOC_LITERAL(9, 101, 9), // "prioritet"
QT_MOC_LITERAL(10, 111, 2), // "op"
QT_MOC_LITERAL(11, 114, 7), // "uradiOp"
QT_MOC_LITERAL(12, 122, 1), // "a"
QT_MOC_LITERAL(13, 124, 1), // "b"
QT_MOC_LITERAL(14, 126, 9), // "izracunaj"
QT_MOC_LITERAL(15, 136, 9) // "karakteri"

    },
    "CalculatorLogic\0resultChanged\0\0"
    "resultHistoryChanged\0setTrenutniRezultat\0"
    "x\0doCommand\0str\0onBtnClicked\0prioritet\0"
    "op\0uradiOp\0a\0b\0izracunaj\0karakteri"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_CalculatorLogic[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
       8,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       2,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    1,   54,    2, 0x06 /* Public */,
       3,    1,   57,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       4,    1,   60,    2, 0x0a /* Public */,
       6,    1,   63,    2, 0x0a /* Public */,
       8,    0,   66,    2, 0x0a /* Public */,
       9,    1,   67,    2, 0x0a /* Public */,
      11,    3,   70,    2, 0x0a /* Public */,
      14,    1,   77,    2, 0x0a /* Public */,

 // signals: parameters
    QMetaType::Void, QMetaType::QString,    2,
    QMetaType::Void, QMetaType::QString,    2,

 // slots: parameters
    QMetaType::Void, QMetaType::QString,    5,
    QMetaType::Void, QMetaType::QString,    7,
    QMetaType::Void,
    QMetaType::Int, QMetaType::QChar,   10,
    QMetaType::Double, QMetaType::Double, QMetaType::Double, QMetaType::QChar,   12,   13,   10,
    QMetaType::Double, QMetaType::QString,   15,

       0        // eod
};

void CalculatorLogic::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<CalculatorLogic *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->resultChanged((*reinterpret_cast< QString(*)>(_a[1]))); break;
        case 1: _t->resultHistoryChanged((*reinterpret_cast< QString(*)>(_a[1]))); break;
        case 2: _t->setTrenutniRezultat((*reinterpret_cast< QString(*)>(_a[1]))); break;
        case 3: _t->doCommand((*reinterpret_cast< QString(*)>(_a[1]))); break;
        case 4: _t->onBtnClicked(); break;
        case 5: { int _r = _t->prioritet((*reinterpret_cast< QChar(*)>(_a[1])));
            if (_a[0]) *reinterpret_cast< int*>(_a[0]) = std::move(_r); }  break;
        case 6: { double _r = _t->uradiOp((*reinterpret_cast< double(*)>(_a[1])),(*reinterpret_cast< double(*)>(_a[2])),(*reinterpret_cast< QChar(*)>(_a[3])));
            if (_a[0]) *reinterpret_cast< double*>(_a[0]) = std::move(_r); }  break;
        case 7: { double _r = _t->izracunaj((*reinterpret_cast< QString(*)>(_a[1])));
            if (_a[0]) *reinterpret_cast< double*>(_a[0]) = std::move(_r); }  break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        {
            using _t = void (CalculatorLogic::*)(QString );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&CalculatorLogic::resultChanged)) {
                *result = 0;
                return;
            }
        }
        {
            using _t = void (CalculatorLogic::*)(QString );
            if (*reinterpret_cast<_t *>(_a[1]) == static_cast<_t>(&CalculatorLogic::resultHistoryChanged)) {
                *result = 1;
                return;
            }
        }
    }
}

QT_INIT_METAOBJECT const QMetaObject CalculatorLogic::staticMetaObject = { {
    &QObject::staticMetaObject,
    qt_meta_stringdata_CalculatorLogic.data,
    qt_meta_data_CalculatorLogic,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *CalculatorLogic::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *CalculatorLogic::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_CalculatorLogic.stringdata0))
        return static_cast<void*>(this);
    return QObject::qt_metacast(_clname);
}

int CalculatorLogic::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QObject::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 8)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 8;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 8)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 8;
    }
    return _id;
}

// SIGNAL 0
void CalculatorLogic::resultChanged(QString _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}

// SIGNAL 1
void CalculatorLogic::resultHistoryChanged(QString _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
