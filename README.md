# Домашнее задание по курсу "Разработка приложений на языке C#"

## Команда и варианты выполненного задания

1. Магомедов Тимур, ИУ6-75 - Реализация ввода данных на базе Windows Forms **(вариант 1.1)**
2. Нехорошева Наталья, ИУ6-75 - Реализация записи в БД при помощи Dapper **(вариант 2.2)**
3. Огарева Екатерина, ИУ6-75 - Реализация чтения из БД при помощи Dapper **(вариант 3.2)**
4. Степанов Эрнест, ИУ6-75 - Реализация отправки данных в виде SOAP ASP.NET, пакет XML **(вариант 4.1)**
5. Дикарев Андрей, ИУ6-71 - Реализация приема данных в виде SOAP ASP.NET, пакет XML **(вариант 5.1)**
6. Королев Александр, ИУ6-71 - Реализация отображения данных на базе ASP.NET Web Forms **(вариант 6.2)**

> Примечание: вариант для функционального блока 5 изначально был 5.5, однако был изменен на 5.1 для соответствия реализаций клиента и веб-сервиса.

## Инструкция по запуску проекта

1. Создать БД из скрипта [dbCreateScript.sql](./dbCreateScript.sql)
2. В файле конфигурации EmissionsInput указать правильную строку подключения к созданной БД
3. Запустить EmissionsInput, БД должна проиницилизироваться (только при первом запуске)
4. Запустить EmissionsWeb
5. В EmissionsService обновить ссылку на службу EmissionsWeb и указать адрес EmissionsWeb
6. Установить EmissionsService в качестве службы windows
7. Запустить EmissionsService
