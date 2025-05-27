using Dapper;
using MySqlConnector;
using System.Windows;
using Diplom.Models;

namespace Diplom.DataBaseConnector
{
    /// <summary>
    /// Singleton-класс для обращения в базу данных.
    /// </summary>
    public class DataBase
    {
        private static DataBase _instance;
        private const string _connectionString = "Server=localhost; Username=root; Password=24681357; Database=Stock";


        private DataBase() { }


        public static DataBase GetInstance()
        {
            return _instance ??= new DataBase();
        }

        #region
        //public IEnumerable<ExecutorViewModel>? GetExecutorCollection()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            var queryString =
        //            """
        //            select id as Id,
        //            executor_name as Name
        //            from executors
        //            """;

        //            return connection.Query<ExecutorViewModel>(queryString);
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Не удалось загрузить данные.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }
        //    }
        //}
        //public IEnumerable<MaterialViewModel>? GetMaterialCollection()
        //{
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            var queryString =
        //            """
        //            select id as Id,
        //            material_name as Name,
        //            stock_quantity as StockQuantity,
        //            measurement_unit as MeasurementUnit
        //            from materials
        //            """;

        //            return connection.Query<MaterialViewModel>(queryString);
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Не удалось загрузить данные.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return null;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Изменяет в базе данных исполнителя и статус заданной заявки.
        ///// В случае ошибки при попытке изменения данных появится сообщение об ошибке.
        ///// </summary>
        ///// <param name="updatedRequest">Обновленная заявка.</param>
        ///// <returns>Возвращает true, если изменение данных прошло успешно, иначе возвращает false.</returns>
        //public bool ChangeRequest(RequestViewModel updatedRequest)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            var queryString =
        //            $"""
        //            update requests
        //            set requests.executor_id = '{updatedRequest?.Executor.Id}',
        //            requests.request_status = '{(int)updatedRequest?.Status}'
        //            where requests.id = '{updatedRequest?.Id}'
        //            """;

        //            connection.Execute(queryString);
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Не удалось обновить заявку.", "Ошибка сохранения!", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }

        //        return true;
        //    }
        //}
        ///// <summary>
        ///// Добавляет в базу данных заданную заявку без Id, Status'а и Executor.Id. Но в базе данных
        ///// поля Id и Status устанавливаются самостоятельно по умолчанию, а поле Executor.Id остается пустым.
        ///// В случае ошибки при попытке добавления данных появится сообщение об ошибке.
        ///// </summary>
        ///// <param name="newRequest">Новая заявка.</param>
        ///// <returns>Возвращает true, если добавление данных прошло успешно, иначе возвращает false.</returns>
        //public bool AddNewRequest(RequestViewModel newRequest)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            var queryString =
        //            $"""
        //            insert into requests(required_quantity, work_type,
        //            time_to_complete, material_id)
        //            values('{newRequest.RequiredQuantity}', '{newRequest.WorkType}',
        //            '{newRequest.TimeToComplete}', '{newRequest.Material.Id}')
        //            """;

        //            connection.Query<RequestViewModel>(queryString);
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Не удалось добавить новую заявку.", "Ошибка сохранения!", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }

        //        return true;
        //    }
        //}
        ///// <summary>
        ///// Изменяет в базе данных количество запасов заданного материала.
        ///// В случае ошибки при попытке изменения данных появится сообщение об ошибке.
        ///// </summary>
        ///// <param name="changedMaterial">Изменяемый материал.</param>
        ///// <param name="changingQuantity">Число, меняющее количество StockQuantity у материала.</param>
        ///// <returns>Возвращает true, если изменение данных прошло успешно, иначе возвращает false.</returns>
        //public bool ChangeMaterialStockQuantity(MaterialViewModel changedMaterial, int changingQuantity)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            if (changedMaterial.StockQuantity + changingQuantity < 0) return false;

        //            var queryString =
        //            $"""
        //            update materials
        //            set materials.stock_quantity = '{changedMaterial.StockQuantity + changingQuantity}'
        //            where materials.id = '{changedMaterial.Id}'
        //            """;

        //            connection.Execute(queryString);
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Не удалось обновить данные материала.", "Ошибка сохранения!", MessageBoxButton.OK, MessageBoxImage.Error);
        //            return false;
        //        }

        //        return true;
        //    }
        //}
        #endregion
        /// <summary>
        /// Проверяет есть ли пользователь в базе данных.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Возвращает true, если пользователь есть в базе данных, иначе возвращает false.</returns>
        public bool Login(string login, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    var queryString =
                    $"""
                    select count(*) from auths
                    where auths.login = '{login}'
                    and auths.password = '{password}'
                    """;

                    var result = connection.ExecuteScalar<int>(queryString);
                    if (result > 0) return true;
                    else return CallErrorMessage();
                }
                catch (Exception)
                {
                    return CallErrorMessage();
                }
            }

            bool CallErrorMessage()
            {
                MessageBox.Show("Такого пользователя не существует.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        /// <summary>
        /// Добавляет в базу данных заданный товар без Id. Но в базе данных
        /// поле Id устанавливается самостоятельно по умолчанию.
        /// В случае ошибки при попытке добавления данных появится сообщение об ошибке.
        /// </summary>
        /// <param name="newProduct">Новый товар.</param>
        /// <returns>Возвращает true, если добавление данных прошло успешно, иначе возвращает false.</returns>
        public bool AddNewProduct(ProductModel newProduct)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    var queryString =
                    $"""
                    insert into products(product_type, product_name,
                    stock_quantity, purchase_price, sale_price, manufacturer)
                    values('{newProduct.Type}', '{newProduct.Name}', '{newProduct.StockQuantity}',
                    '{newProduct.PurchasePrice}', '{newProduct.SalePrice}', '{newProduct.Manufacturer}')
                    """;

                    connection.Query<ProductModel>(queryString);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось добавить новый товар.", "Ошибка сохранения!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                return true;
            }
        }
        /// <summary>
        /// Удаляет из базы данных заданный продукт. В случае ошибки при выполнении появится сообщение об ошибке.
        /// </summary>
        /// <param name="deletedProduct">Удаляемый продукт.</param>
        /// <returns>Возвращает true, если удаление данных прошло успешно, иначе возвращает false.</returns>
        public bool DeleteProduct(ProductModel deletedProduct)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    var queryString =
                    $"""
                    delete from products
                    where products.id = '{deletedProduct.Id}'
                    """;

                    connection.Execute(queryString);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось удалить данные.", "Ошибка удаления!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                return true;
            }
        }
        /// <summary>
        /// Изменяет в базе данных количество на складе заданного товара.
        /// В случае ошибки при попытке изменения данных появится сообщение об ошибке.
        /// </summary>
        /// <param name="updatedProduct">Обновленный товар.</param>
        /// /// <param name="changingQuantity">Число, меняющее количество StockQuantity у товара.</param>
        /// <returns>Возвращает true, если изменение данных прошло успешно, иначе возвращает false.</returns>
        public bool ChangeProduct(ProductModel updatedProduct, int changingQuantity)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    if (updatedProduct.StockQuantity + changingQuantity < 0) return false;

                    var queryString =
                    $"""
                    update products
                    set products.stock_quantity = '{updatedProduct?.StockQuantity + changingQuantity}'
                    where products.id = '{updatedProduct?.Id}'
                    """;

                    connection.Execute(queryString);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось обновить данные продукта.", "Ошибка изменения!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                return true;
            }
        }

        public IEnumerable<ProductModel>? GetProductCollection()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    var queryString =
                    """
                    select id as Id,
                    product_type as Type,
                    product_name as Name,
                    stock_quantity as StockQuantity,
                    purchase_price as PurchasePrice,
                    sale_price as SalePrice,
                    manufacturer as Manufacturer
                    from products
                    """;

                    return connection.Query<ProductModel>(queryString);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось загрузить данные.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }
        public IEnumerable<ProductModel>? GetPurchasedProductsCollection()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    var queryString =
                    $"""
                    select id as Id,
                    product_type as Type,
                    product_name as Name,
                    stock_quantity as StockQuantity,
                    purchase_price as PurchasePrice,
                    sale_price as SalePrice,
                    manufacturer as Manufacturer
                    from products
                    where stock_quantity between '{0}' and '{Application.Current.Resources["RedBorder"]}'
                    """;

                    return connection.Query<ProductModel>(queryString);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось загрузить данные.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }
    }
}
